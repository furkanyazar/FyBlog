using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IWriterService _writerService;

        private UserLoginValidator userLoginValidator = new UserLoginValidator();
        private ValidationResult validation;

        public LoginController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            validation = userLoginValidator.Validate(userLoginDto);

            if (validation.IsValid)
            {
                var userToCheck = _writerService.GetByUserEmail(userLoginDto.UserEmail);

                if (userToCheck is null)
                {
                    ModelState.AddModelError("UserEmail", "E-posta hatalı");

                    return View();
                }

                if (!HashingHelper.VerifyPasswordHash(userLoginDto.UserPassword, userToCheck.User.UserPasswordHash, userToCheck.User.UserPasswordSalt))
                {
                    ModelState.AddModelError("UserPassword", "Şifre hatalı");

                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim("UserId", userToCheck.UserId.ToString())
                };

                var claimIdentity = new ClaimsIdentity(claims, "A");
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Writer");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}
