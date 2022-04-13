using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var result = _blogService.GetAllWithCategory().OrderByDescending(x => x.BlogDateOf).ToList();

            return View(result);
        }
    }
}
