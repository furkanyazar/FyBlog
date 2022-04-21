using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Blog
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
            int result = _blogService.GetAllByCategoryIdAndCategoryStatusAndBlogStatus(categoryId, true, true).Count;

            return View(result);
        }
    }
}
