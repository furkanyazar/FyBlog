using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var result = _categoryService.GetAll();

            return View(result);
        }
    }
}
