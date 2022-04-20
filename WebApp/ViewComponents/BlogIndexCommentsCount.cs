using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
	public class BlogIndexCommentsCount : ViewComponent
	{
		private ICommentService _commentService;

		public BlogIndexCommentsCount(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IViewComponentResult Invoke(int blogId)
		{
			int result = _commentService.GetAllByBlogIdWithUser(blogId).Count;

			return View(result);
		}
	}
}
