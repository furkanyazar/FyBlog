using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
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

		private LoginValidator loginValidator = new LoginValidator();
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
		public async Task<IActionResult> Index(User user)
		{
			validation = loginValidator.Validate(user);

			if (validation.IsValid)
			{
				var result = _writerService.GetByUserEmailAndUserPassword(user);

				if (result is not null)
				{
					var claims = new List<Claim>
					{
						new Claim("UserId", result.UserId.ToString()),
						new Claim("UserEmail", result.User.UserEmail),
						new Claim("UserFirstName", result.User.UserFirstName),
						new Claim("UserLastName", result.User.UserLastName),
						new Claim("WriterImageUrl", result.WriterImageUrl)
					};

					var claimIdentity = new ClaimsIdentity(claims, "A");
					var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

					await HttpContext.SignInAsync(claimsPrincipal);

					return RedirectToAction("Index", "Writer");
				}
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
