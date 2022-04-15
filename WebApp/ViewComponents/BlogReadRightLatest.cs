using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.ViewComponents
{
	public class BlogReadRightLatest : ViewComponent
	{
		private IBlogService _blogService;

		public BlogReadRightLatest(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogService.GetAll().LastOrDefault();

			return View(result);
		}
	}
}
