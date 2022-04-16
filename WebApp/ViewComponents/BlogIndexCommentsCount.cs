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

		public IViewComponentResult Invoke(int id)
		{
			int result = _commentService.GetAllByBlogId(id).Count;

			return View(result);
		}
	}
}
