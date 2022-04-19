using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.DTOs;
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

        private UserRegisterValidator userRegisterValidator = new UserRegisterValidator();
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
        public IActionResult Index(UserRegisterDto userRegisterDto)
        {
            validation = userRegisterValidator.Validate(userRegisterDto);

            if (validation.IsValid)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userRegisterDto.UserPassword, out passwordHash, out passwordSalt);

                var user = new User
                {
                    UserEmail = userRegisterDto.UserEmail,
                    UserFirstName = userRegisterDto.UserFirstName,
                    UserLastName = userRegisterDto.UserLastName,
                    UserPasswordHash = passwordHash,
                    UserPasswordSalt = passwordSalt
                };

                _userService.Add(user);

                var writer = new Writer
                {
                    UserId = _userService.GetAll().LastOrDefault().UserId,
                    WriterImageUrl = Defaults.DEFAULT_AVATAR_URL
                };

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
