using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
    public class HomeLatestBlog : ViewComponent
    {
        private IBlogService _blogService;

		public HomeLatestBlog(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _blogService.GetLatest();

			return View(result);
		}
	}
}
