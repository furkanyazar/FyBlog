using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();

        List<Comment> GetAllByBlogId(int id);

        Comment GetById(int id);

        void Add(Comment comment);

        void Update(Comment comment);

        void Delete(Comment comment);
    }
}
