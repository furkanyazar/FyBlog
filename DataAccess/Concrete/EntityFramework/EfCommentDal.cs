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
        public List<Comment> GetAllByBlogIdWithUser(int blogId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Comments.Where(x => x.BlogId == blogId).Include(x => x.User).ToList();
            }
        }

        public List<Comment> GetAllByLastWeekAndBlogId(int blogId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Comments.Where(x => x.BlogId == blogId && x.CommentDateOf >= DateTime.Now.AddDays(-7)).ToList();
            }
        }
    }
}
