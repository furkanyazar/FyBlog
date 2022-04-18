using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterIndexMyLatestBlogs : ViewComponent
    {
        private IBlogService _blogService;

        public WriterIndexMyLatestBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var result = _blogService.GetLatestsByWriterIdWithCount(id, 5);

            return View(result);
        }
    }
}
