using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Blog
{
	public class BlogFooterLatestBlogs : ViewComponent
	{
		private IBlogService _blogService;

		public BlogFooterLatestBlogs(IBlogService blogService)
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
