using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class BlogReadComments : ViewComponent
    {
        private ICommentService _commentService;

        public BlogReadComments(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var result = _commentService.GetAllByBlogId(id);

            return View(result);
        }
    }
}
