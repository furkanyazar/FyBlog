using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepository<Comment, MvcCoreDbContext>, ICommentDal
    {
        public List<Comment> GetAllByBlogId(int blogId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Comments.Where(x => x.BlogId == blogId && x.CommentStatus).Include(x => x.Blog).Include(x => x.Blog.Category).Include(x => x.Blog.Writer).Include(x => x.Blog.Writer.User).Include(x => x.User).ToList();
            }
        }

        public List<Comment> GetAllByLastWeekAndBlogId(int blogId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Comments.Where(x => x.BlogId == blogId && x.CommentDateOf >= DateTime.Now.AddDays(-7)).Include(x => x.Blog).Include(x => x.Blog.Category).Include(x => x.Blog.Writer).Include(x => x.Blog.Writer.User).Include(x => x.User).ToList();
            }
        }
    }
}
