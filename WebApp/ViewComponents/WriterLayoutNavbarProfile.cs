using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterLayoutNavbarProfile : ViewComponent
    {
        private IWriterService _writerService;

        public WriterLayoutNavbarProfile(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var result = _writerService.GetByIdWithUser(id);

            return View(result);
        }
    }
}
