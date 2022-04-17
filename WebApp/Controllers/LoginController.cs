using Business.Abstract;
using Entities.Concrete;
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
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var result = _userService.GetByEmailAndPassword(user);

            if (result is not null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, result.UserEmail),
                    new Claim(ClaimTypes.Name, result.UserFirstName),
                    new Claim(ClaimTypes.Surname, result.UserLastName),
                };

                var claimIdentity = new ClaimsIdentity(claims, "A");
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Blog");
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
