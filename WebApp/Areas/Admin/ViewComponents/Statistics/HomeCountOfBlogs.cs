using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
	public class HomeCountOfBlogs : ViewComponent
	{
		private IBlogService _blogService;

		public HomeCountOfBlogs(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogService.GetAll().Count;

			return View(result);
		}
	}
}
