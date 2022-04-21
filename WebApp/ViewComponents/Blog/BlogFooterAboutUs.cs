using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.ViewComponents.Blog
{
	public class BlogFooterAboutUs : ViewComponent
	{
		private IAboutService _aboutService;

		public BlogFooterAboutUs(IAboutService aboutService)
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
