using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterIndexLatestBlogs : ViewComponent
    {
        private IBlogService _blogService;

        public WriterIndexLatestBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _blogService.GetLatestsWithCount(5);

            return View(result);
        }
    }
}
