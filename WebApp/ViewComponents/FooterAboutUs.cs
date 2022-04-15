using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.ViewComponents
{
	public class FooterAboutUs : ViewComponent
	{
		private IAboutService _aboutService;

		public FooterAboutUs(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _aboutService.GetAll().LastOrDefault();

			return View(result);
		}
	}
}
