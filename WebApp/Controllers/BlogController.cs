using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var result = _blogService.GetAllByCategoryStatusAndBlogStatus(true, true);

            return View(result);
        }

        public IActionResult Read(int blogId)
        {
            var result = _blogService.GetByBlogId(blogId);

            return View(result);
        }

        public IActionResult Category(int categoryId)
        {
            var result = _blogService.GetAllByCategoryIdAndCategoryStatusAndBlogStatus(categoryId, true, true);

            return View(result);
        }

        public IActionResult Writer(int writerId)
        {
            var result = _blogService.GetAllByWriterIdAndCategoryStatusAndBlogStatus(writerId, true, true);

            return View(result);
        }

        public IActionResult Date(string dateOf)
        {
            var result = _blogService.GetAllByDateOfAndCategoryStatusAndBlogStatus(DateTime.Parse(dateOf), true, true);

            return View(result);
        }

        public IActionResult Search(string searchKey)
        {
            var result = _blogService.GetAllBySearchKeyAndCategoryStatusAndBlogStatus(searchKey, true, true);

            return View(result);
        }
    }
}
