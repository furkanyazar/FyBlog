using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Layout
{
    public class AdminLayoutSidebarNewSpanForContact : ViewComponent
    {
        private IContactService _contactService;

        public AdminLayoutSidebarNewSpanForContact(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _contactService.GetAllByStatus(false).Count;

            return View(result);
        }
    }
}
