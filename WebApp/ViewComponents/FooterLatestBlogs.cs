using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
	public class FooterLatestBlogs : ViewComponent
	{
		private IBlogService _blogService;

		public FooterLatestBlogs(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogService.GetLatestsByCategoryStatusAndBlogStatusWithCount(3, true, true);

			return View(result);
		}
	}
}
