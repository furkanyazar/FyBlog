using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class BlogReadRightCategoriesCount : ViewComponent
    {
        private IBlogService _blogService;

        public BlogReadRightCategoriesCount(IBlogService categoryService)
        {
            _blogService = categoryService;
        }

        public IViewComponentResult Invoke(int id)
        {
            int result = _blogService.GetAllByCategoryId(id).Count;

            return View(result);
        }
    }
}
