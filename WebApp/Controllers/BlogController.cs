using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using X.PagedList;

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

        public IActionResult Index(int page = 1)
        {
            var result = _blogService.GetAllByCategoryStatusAndBlogStatus(true, true);

            return View(result.ToPagedList(page, 9));
        }

        public IActionResult Read(int blogId)
        {
            var result = _blogService.GetByBlogId(blogId);

            return View(result);
        }

        public IActionResult Category(int categoryId, int page = 1)
        {
            var result = _blogService.GetAllByCategoryIdAndCategoryStatusAndBlogStatus(categoryId, true, true);

            return View(result.ToPagedList(page, 9));
        }

        public IActionResult Writer(int writerId, int page = 1)
        {
            var result = _blogService.GetAllByWriterIdAndCategoryStatusAndBlogStatus(writerId, true, true);

            return View(result.ToPagedList(page, 9));
        }

        public IActionResult Date(string dateOf, int page = 1)
        {
            var result = _blogService.GetAllByDateOfAndCategoryStatusAndBlogStatus(DateTime.Parse(dateOf), true, true);

            return View(result.ToPagedList(page, 9));
        }

        public IActionResult Search(string searchKey, int page = 1)
        {
            var result = _blogService.GetAllBySearchKeyAndCategoryStatusAndBlogStatus(searchKey, true, true);

            return View(result.ToPagedList(page, 9));
        }
    }
}
