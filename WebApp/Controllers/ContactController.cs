using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private IContactService _contactService;

        private ContactValidator contactValidator = new ContactValidator();
        private ValidationResult validation;

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
            validation = contactValidator.Validate(contact);

            if (validation.IsValid)
            {
                _contactService.Add(contact);

                return RedirectToAction("Index", "Contact", new { Status = true }, "contact");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
