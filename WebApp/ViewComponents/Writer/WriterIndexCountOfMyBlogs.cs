using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Writer
{
    public class WriterIndexCountOfMyBlogs : ViewComponent
    {
        private IBlogService _blogService;

        public WriterIndexCountOfMyBlogs(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var result = _blogService.GetAllByUserId(userId).Count;

            return View(result);
        }
    }
}
