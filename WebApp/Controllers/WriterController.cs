using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
    public class WriterController : Controller
    {
        private IBlogService _blogService;

        public WriterController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Blog(int id)
        {
            var result = _blogService.GetAllByWriterIdWithCategoryAndWriter(id);

            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var result = _blogService.GetByIdWithCategoryAndWriter(id);
            result.BlogStatus = result.BlogStatus ? false : true;

            _blogService.Update(result);

            return RedirectToAction("Blog", new { Id = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserId").Value });
        }
    }
}
