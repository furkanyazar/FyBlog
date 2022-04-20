using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService : IEntityService<Comment>
    {
        List<Comment> GetAllByBlogIdWithUser(int blogId);

        List<Comment> GetAllByLastWeekAndBlogId(int blogId);
    }
}
