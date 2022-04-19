using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
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
		private IWriterService _writerService;

		private BlogValidator blogValidator = new BlogValidator();
		private WriterValidator writerValidator = new WriterValidator();
		private ValidationResult validation;

		public WriterController(IBlogService blogService, ICategoryService categoryService, IWriterService writerService)
		{
			_blogService = blogService;
			_categoryService = categoryService;
			_writerService = writerService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Profile(int id)
		{
			var result = _writerService.GetByIdWithUser(id);

			return View(result);
		}

		[HttpPost]
		public IActionResult Profile(Writer writer)
		{
			if (writer.User.UserPassword is null)
				writer.User.UserPassword = Defaults.PASSWORD_KEY;

			validation = writerValidator.Validate(writer);

			if (validation.IsValid)
			{
				if (Request.Form.Files["WriterImage"] is not null)
				{
					string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Request.Form.Files[0].FileName);
					string path = Path.Combine(Directory.GetCurrentDirectory(), Defaults.DEFAULT_PROFILE_PHOTO_UPLOAD_PATH, fileName);

					var stream = new FileStream(path, FileMode.Create);
					Request.Form.Files["WriterImage"].CopyTo(stream);

					writer.WriterImageUrl = Defaults.DEFAULT_PROFILE_PHOTO_URL_PATH + fileName;

					stream.Close();
				}

				if (writer.User.UserPassword == Defaults.PASSWORD_KEY)
						writer.User.UserPassword = _writerService.GetByIdWithUser(writer.UserId).User.UserPassword;

				_writerService.Update(writer);

				return RedirectToAction("Index");
			}

			foreach (var item in validation.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

			return View();
		}

		public IActionResult DeletePhoto(int id)
		{
			var result = _writerService.GetByIdWithUser(id);
			result.WriterImageUrl = Defaults.DEFAULT_AVATAR_URL;

			_writerService.Update(result);

			return RedirectToAction("Profile", new { Id = id });
		}

		public IActionResult MyBlogs(int id)
		{
			var result = _blogService.GetAllByWriterId(id);

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
			blog.WriterId = Convert.ToInt32(HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value);

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

				return RedirectToAction("MyBlogs", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
			}

			foreach (var item in validation.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View();
		}

		[HttpGet]
		public IActionResult UpdateBlog(int id)
		{
			var result = _blogService.GetById(id);

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View(result);
		}

		[HttpPost]
		public IActionResult UpdateBlog(Blog blog)
		{
			var result = _blogService.GetById(blog.BlogId);

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

				return RedirectToAction("MyBlogs", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
			}

			foreach (var item in validation.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View();
		}

		public IActionResult DeleteBlog(int id)
		{
			var result = _blogService.GetById(id);

			result.BlogStatus = result.BlogStatus ? false : true;

			_blogService.Update(result);

			return RedirectToAction("MyBlogs", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
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
