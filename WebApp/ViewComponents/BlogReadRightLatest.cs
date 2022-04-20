using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class BlogReadRightLatest : ViewComponent
    {
        private IBlogService _blogService;

        public BlogReadRightLatest(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetLatestByCategoryStatusAndBlogStatus(true, true);

            return View(result);
        }
    }
}
