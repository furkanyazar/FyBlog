using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Blog
{
	public class BlogReadRightSimilarBlogs : ViewComponent
	{
		private IBlogService _blogService;

		public BlogReadRightSimilarBlogs(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IViewComponentResult Invoke(int blogId, int categoryId)
		{
			var result = _blogService.GetAllByCategoryIdAndCategoryStatusAndBlogStatusWithCountWithoutBlogId(3, blogId, categoryId, true, true);

			return View(result);
		}
	}
}
