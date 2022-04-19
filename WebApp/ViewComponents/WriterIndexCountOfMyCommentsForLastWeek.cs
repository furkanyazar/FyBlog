using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterIndexCountOfMyCommentsForLastWeek : ViewComponent
    {
        private IBlogService _blogService;
        private ICommentService _commentService;

        public WriterIndexCountOfMyCommentsForLastWeek(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int writerId)
        {
            int count = 0;

            var blogs = _blogService.GetAllByWriterId(writerId);

            foreach (var blog in blogs)
                count += _commentService.GetAllByLastWeekAndBlogId(blog.BlogId).Count;

            return View(count);
        }
    }
}
