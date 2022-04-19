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

        public IViewComponentResult Invoke(int categoryId)
        {
            int result = _blogService.GetAllByCategoryId(categoryId).Count;

            return View(result);
        }
    }
}
