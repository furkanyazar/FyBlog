using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterIndexCountOfMyBlogs : ViewComponent
    {
        private IBlogService _blogService;

        public WriterIndexCountOfMyBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int writerId)
        {
            var result = _blogService.GetAllByWriterId(writerId).Count;

            return View(result);
        }
    }
}
