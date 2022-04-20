using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterLayoutSidebarProfile : ViewComponent
    {
        private IWriterService _writerService;

        public WriterLayoutSidebarProfile(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            var result = _writerService.GetByUserId(userId);

            return View(result);
        }
    }
}
