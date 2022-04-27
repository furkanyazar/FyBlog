using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var result = _contactService.GetAll().OrderByDescending(x => x.ContactDateOf).ToList();

            return View(result);
        }

        public IActionResult Read(int id)
        {
            var result = _contactService.GetById(id);

            result.ContactStatus = true;

            _contactService.Update(result);

            return View(result);
        }
    }
}
