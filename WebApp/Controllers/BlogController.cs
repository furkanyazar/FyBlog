using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            var result = _blogService.GetAllWithCategoryAndWriter().ToList();

            return View(result);
        }

        public IActionResult Read(int blogId)
        {
            var result = _blogService.GetByBlogId(blogId);

            return View(result);
        }

        public IActionResult Category(int categoryId)
        {
            var result = _blogService.GetAllByCategoryId(categoryId);

            return View(result);
        }

        public IActionResult Writer(int writerId)
        {
            var result = _blogService.GetAllByWriterId(writerId);

            return View(result);
        }

        public IActionResult Date(string dateOf)
        {
            var result = _blogService.GetAllByDateOf(DateTime.Parse(dateOf));

            return View(result);
        }

        public IActionResult Search(string searchKey)
        {
            var result = _blogService.GetAllBySearchKey(searchKey);

            return View(result);
        }
    }
}
