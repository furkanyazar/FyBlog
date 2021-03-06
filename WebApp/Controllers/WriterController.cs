using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApp.Controllers
{
    public class WriterController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        private IUserService _userService;
        private IWriterService _writerService;
        private INotificationService _notificationService;

        private IMapper _mapper;

        private BlogValidator blogValidator = new BlogValidator();
        private WriterValidator writerValidator = new WriterValidator();
        private ValidationResult validation;

        public WriterController(IBlogService blogService, ICategoryService categoryService, IUserService userService, IMapper mapper, IWriterService writerService, INotificationService notificationService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _userService = userService;
            _mapper = mapper;
            _writerService = writerService;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile(int userId)
        {
            var writer = _writerService.GetByUserId(userId);

            var result = _mapper.Map<WriterDto>(writer);

            return View(result);
        }

        [HttpPost]
        public IActionResult Profile(WriterDto writerDto)
        {
            var oldWriter = _writerService.GetByUserId(writerDto.UserId);

            if (writerDto.UserPassword is null)
                writerDto.UserPassword = Defaults.PASSWORD_KEY;

            validation = writerValidator.Validate(writerDto);

            if (validation.IsValid)
            {
                if (Request.Form.Files["UserImage"] is not null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                    string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_PROFILE_PHOTO_UPLOAD_PATH, fileName);

                    var stream = new FileStream(path, FileMode.Create);
                    Request.Form.Files["UserImage"].CopyTo(stream);

                    writerDto.UserImageUrl = Defaults.DEFAULT_PROFILE_PHOTO_URL_PATH + fileName;

                    stream.Close();
                }

                var writer = _mapper.Map<Writer>(writerDto);
                writer.WriterId = oldWriter.WriterId;

                if (writerDto.UserPassword == Defaults.PASSWORD_KEY)
                {
                    writer.User.UserPasswordHash = oldWriter.User.UserPasswordHash;
                    writer.User.UserPasswordSalt = oldWriter.User.UserPasswordSalt;
                }
                else
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(writerDto.UserPassword, out passwordHash, out passwordSalt);

                    writer.User.UserPasswordHash = passwordHash;
                    writer.User.UserPasswordSalt = passwordSalt;
                }

                _userService.Update(writer.User);
                _writerService.Update(writer);

                return RedirectToAction("Index");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public IActionResult DeletePhoto(int userId)
        {
            var result = _userService.GetByUserId(userId);
            result.UserImageUrl = Defaults.DEFAULT_AVATAR_URL;

            _userService.Update(result);

            return RedirectToAction("Profile", new { userId = userId });
        }

        public IActionResult MyBlogs(int userId)
        {
            var result = _blogService.GetAllByUserId(userId);

            return View(result);
        }

        public IActionResult MyBlogsByCategory(int writerId, int categoryId)
        {
            var result = _blogService.GetAllByCategoryIdAndWriterId(writerId, categoryId);

            return View(result);
        }

        public IActionResult MyBlogsByDate(int writerId, string dateOf)
        {
            var result = _blogService.GetAllByDateOfAndWriterId(writerId, DateTime.Parse(dateOf));

            return View(result);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.Categories = GetCategoriesSeletListItems();

            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            var writer = _writerService.GetByUserId(Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value));

            blog.WriterId = writer.WriterId;

            if (Request.Form.Files["BlogImage"] is not null && Request.Form.Files["BlogThumbnailImage"] is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                var stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["BlogImage"].CopyTo(stream);

                blog.BlogImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[1].FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["BlogThumbnailImage"].CopyTo(stream);

                blog.BlogThumbnailImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                stream.Close();
            }

            validation = blogValidator.Validate(blog);

            if (validation.IsValid)
            {
                _blogService.Add(blog);

                return RedirectToAction("MyBlogs", new { userId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Categories = GetCategoriesSeletListItems();

            return View();
        }

        [HttpGet]
        public IActionResult UpdateBlog(int blogId)
        {
            var result = _blogService.GetByBlogId(blogId);

            ViewBag.Categories = GetCategoriesSeletListItems();

            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            var result = _blogService.GetByBlogId(blog.BlogId);

            blog.WriterId = result.WriterId;
            blog.BlogDateOf = result.BlogDateOf;

            if (Request.Form.Files["BlogImage"] is null)
                blog.BlogImageUrl = result.BlogImageUrl;

            if (Request.Form.Files["BlogThumbnailImage"] is null)
                blog.BlogThumbnailImageUrl = result.BlogThumbnailImageUrl;

            if (Request.Form.Files["BlogImage"] is not null && Request.Form.Files["BlogThumbnailImage"] is not null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                var stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["BlogImage"].CopyTo(stream);

                blog.BlogImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[1].FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                stream = new FileStream(path, FileMode.Create);
                Request.Form.Files["BlogThumbnailImage"].CopyTo(stream);

                blog.BlogThumbnailImageUrl = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;

                stream.Close();
            }

            validation = blogValidator.Validate(blog);

            if (validation.IsValid)
            {
                _blogService.Update(blog);

                return RedirectToAction("MyBlogs", new { userId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            ViewBag.Categories = GetCategoriesSeletListItems();

            return View();
        }

        public IActionResult DeleteBlog(int blogId)
        {
            var result = _blogService.GetByBlogId(blogId);

            result.BlogStatus = result.BlogStatus ? false : true;

            _blogService.Update(result);

            return RedirectToAction("MyBlogs", new { userId = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
        }

        [HttpPost]
        public IActionResult UploadFile(List<IFormFile> files)
        {
            var result = "";

            foreach (var item in Request.Form.Files)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(item.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_IMAGE_UPLOAD_PATH, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                item.CopyTo(stream);

                result = Defaults.DEFAULT_IMAGE_URL_PATH + fileName;
            }

            return Json(new { url = result });
        }

        public ICollection<SelectListItem> GetCategoriesSeletListItems()
        {
            return (from x in _categoryService.GetAllByStatus(true)
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryId.ToString()
                    }).ToList();
        }
    }
}
