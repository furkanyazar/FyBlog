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

		private BlogValidator _blogValidator = new BlogValidator();
		private ValidationResult _validation;

		public WriterController(IBlogService blogService, ICategoryService categoryService)
		{
			_blogService = blogService;
			_categoryService = categoryService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MyBlogs(int id)
		{
			var result = _blogService.GetAllByWriterIdWithCategoryAndWriter(id);

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

			_validation = _blogValidator.Validate(blog);

			if (_validation.IsValid)
			{
				_blogService.Add(blog);

				return RedirectToAction("MyBlogs", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
			}

			foreach (var item in _validation.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View();
		}

		[HttpGet]
		public IActionResult UpdateBlog(int id)
		{
			var result = _blogService.GetByIdWithCategoryAndWriter(id);

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View(result);
		}

		[HttpPost]
		public IActionResult UpdateBlog(Blog blog)
		{
			var result = _blogService.GetByIdWithCategoryAndWriter(blog.BlogId);

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

			_validation = _blogValidator.Validate(blog);

			if (_validation.IsValid)
			{
				_blogService.Update(blog);

				return RedirectToAction("MyBlogs", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
			}

			foreach (var item in _validation.Errors)
			{
				ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
			}

			ViewBag.Categories = GetCategoriesSeletListItems();

			return View();
		}

		public IActionResult DeleteBlog(int id)
		{
			var result = _blogService.GetByIdWithCategoryAndWriter(id);

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
