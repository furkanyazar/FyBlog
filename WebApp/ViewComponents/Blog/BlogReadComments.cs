using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Blog
{
    public class BlogReadComments : ViewComponent
    {
        private ICommentService _commentService;

        public BlogReadComments(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int blogId)
        {
            var result = _commentService.GetAllByBlogId(blogId);

            return View(result);
        }
    }
}
