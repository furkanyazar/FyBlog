﻿using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class WriterIndexCountOfMyComments : ViewComponent
    {
        private IBlogService _blogService;
        private ICommentService _commentService;

        public WriterIndexCountOfMyComments(IBlogService blogService, ICommentService commentService)
        {
            _blogService = blogService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int userId)
        {
            int count = 0;

            var blogs = _blogService.GetAllByUserId(userId);

            foreach (var blog in blogs)
                count += _commentService.GetAllByBlogId(blog.BlogId).Count;

            return View(count);
        }
    }
}
