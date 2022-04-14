using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class BlogReadRightCategories : ViewComponent
    {
        private ICategoryService _categoryService;

        public BlogReadRightCategories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _categoryService.GetAllByStatus(true);

            return View(result);
        }
    }
}
