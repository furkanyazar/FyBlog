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

        public List<Comment> GetAllByBlogId(int id)
        {
            return _tdal.GetAll(x => x.BlogId == id);
        }
    }
}
