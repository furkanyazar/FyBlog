using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Areas.Admin.ViewComponents.Layout
{
    public class AdminLayoutSidebarCountOfWriters : ViewComponent
    {
        private IWriterService _writerService;

        public AdminLayoutSidebarCountOfWriters(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _writerService.GetAllWithIncludes().Where(x => x.User.UserStatus).Count();

            return View(result);
        }
    }
}
