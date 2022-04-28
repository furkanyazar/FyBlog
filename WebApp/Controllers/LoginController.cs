using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IWriterService _writerService;
        private IUserService _userService;
        private IAdminService _adminService;

        private UserLoginValidator userLoginValidator = new UserLoginValidator();
        private ValidationResult validation;

        public LoginController(IWriterService writerService, IUserService userService, IAdminService adminService)
        {
            _writerService = writerService;
            _userService = userService;
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Claims.Count() > 0)
                return RedirectToAction("Index", "Blog");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            validation = userLoginValidator.Validate(userLoginDto);

            if (validation.IsValid)
            {
                var writerToCheck = _writerService.GetByUserEmail(userLoginDto.UserEmail);

                if (writerToCheck is not null)
                {
                    ModelState.AddModelError("UserEmail", "E-posta hatalı");

                    return View();
                }

                var adminToCheck = _adminService.GetByUserEmail(userLoginDto.UserEmail);

                if (adminToCheck is not null)
                {
                    ModelState.AddModelError("UserEmail", "E-posta hatalı");

                    return View();
                }

                var userToCheck = _userService.GetByUserEmail(userLoginDto.UserEmail);

                if (userToCheck is null)
                {
                    ModelState.AddModelError("UserEmail", "E-posta hatalı");

                    return View();
                }

                if (!HashingHelper.VerifyPasswordHash(userLoginDto.UserPassword, userToCheck.UserPasswordHash, userToCheck.UserPasswordSalt))
                {
                    ModelState.AddModelError("UserPassword", "Şifre hatalı");

                    return View();
                }

                var claims = new List<Claim>
                {
                    new Claim("UserId", userToCheck.UserId.ToString())
                };

                var claimIdentity = new ClaimsIdentity(claims, "U");
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Blog");
            }

            foreach (var item in validation.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Writer()
        {
            if (User.Claims.Count() > 0)
                return RedirectToAction("Index", "Blog");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Writer(UserLoginDto userLoginDto)
        {
            validation = userLoginValidator.Validate(userLoginDto);

            if (validation.IsValid)
            {
                var userToCheck = _writerService.GetByUserEmail(userLoginDto.UserEmail);

                if (!userToCheck.User.UserStatus)
                {
                    ModelState.AddModelError("UserEmail", "Hesap askıya alındı");

                    return View();
                }

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

                var claimIdentity = new ClaimsIdentity(claims, "W");
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

        [HttpGet]
        public IActionResult Admin()
        {
            if (User.Claims.Count() > 0)
                return RedirectToAction("Index", "Blog");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Admin(UserLoginDto userLoginDto)
        {
            validation = userLoginValidator.Validate(userLoginDto);

            if (validation.IsValid)
            {
                var userToCheck = _adminService.GetByUserEmail(userLoginDto.UserEmail);

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

                return RedirectToAction("Index", "Admin");
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

            return RedirectToAction("Index", "Blog");
        }
    }
}
