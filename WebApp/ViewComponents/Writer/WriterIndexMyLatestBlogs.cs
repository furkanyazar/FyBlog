using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterIndexMyLatestBlogs : ViewComponent
    {
        private IBlogService _blogService;

        public WriterIndexMyLatestBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var result = _blogService.GetLatestsByUserIdWithCount(userId, 5);

            return View(result);
        }
    }
}
