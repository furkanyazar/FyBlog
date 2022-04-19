using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CommentManager : EntityManager<Comment, ICommentDal>, ICommentService
    {
        public CommentManager(ICommentDal tdal) : base(tdal)
        {
        }

        public List<Comment> GetAllByBlogId(int blogId)
        {
            return _tdal.GetAll(x => x.BlogId == blogId);
        }

        public List<Comment> GetAllByLastWeekAndBlogId(int blogId)
        {
            return _tdal.GetAllByLastWeekAndBlogId(blogId);
        }
    }
}
