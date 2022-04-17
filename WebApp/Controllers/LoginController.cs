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
		private IWriterService _writerService;

		public LoginController(IUserService userService, IWriterService writerService)
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
		public async Task<IActionResult> Index(User user)
		{
			var result = _userService.GetByEmailAndPassword(user);

			if (result is not null)
			{
				var writer = _writerService.GetById(result.UserId);

				var claims = new List<Claim>
				{
					new Claim("UserEmail", result.UserEmail),
					new Claim("UserFirstName", result.UserFirstName),
					new Claim("UserLastName", result.UserLastName),
					new Claim("WriterImageUrl", writer.WriterImageUrl)
				};

				var claimIdentity = new ClaimsIdentity(claims, "A");
				var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

				await HttpContext.SignInAsync(claimsPrincipal);

				return RedirectToAction("Index", "Writer");
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
