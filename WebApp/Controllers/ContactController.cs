using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _contactService;

        private ContactValidator _contactValidator = new ContactValidator();
        private ValidationResult _validation;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _validation = _contactValidator.Validate(contact);

            if (_validation.IsValid)
            {
                _contactService.Add(contact);

                return RedirectToAction("Index", "Contact", new { Status = true }, "contact");
            }

            foreach (var item in _validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
