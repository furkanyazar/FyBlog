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

        private UserRegisterValidator userRegisterValidator = new UserRegisterValidator();
        private ValidationResult validation;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Claims.Count() > 0)
                return RedirectToAction("Index", "Blog");

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
                    UserImageUrl = Defaults.DEFAULT_AVATAR_URL,
                    UserPasswordHash = passwordHash,
                    UserPasswordSalt = passwordSalt
                };

                _userService.Add(user);

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
