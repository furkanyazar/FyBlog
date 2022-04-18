using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private IUserService _userService;
        private IWriterService _writerService;

        private UserValidator userValidator = new UserValidator();
        private ValidationResult validation;

        public RegisterController(IUserService userService, IWriterService writerService)
        {
            _userService = userService;
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            validation = userValidator.Validate(user);

            if (validation.IsValid)
            {
                _userService.Add(user);

                Writer writer = new Writer { UserId = _userService.GetAll().LastOrDefault().UserId, WriterImageUrl = Defaults.DEFAULT_AVATAR_URL };

                _writerService.Add(writer);

                return RedirectToAction("Index", "Login");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
    }
}
