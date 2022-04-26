using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
	public class HomeCountOfComments : ViewComponent
	{
		private ICommentService _commentService;

		public HomeCountOfComments(ICommentService commentService)
		{
			_commentService = commentService;
		}

		public IViewComponentResult Invoke()
		{
			var result = _commentService.GetAll().Count;

			return View(result);
		}
	}
}
