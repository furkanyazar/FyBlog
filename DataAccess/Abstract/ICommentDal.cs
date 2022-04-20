﻿using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        List<Comment> GetAllByBlogIdWithUser(int blogId);

        List<Comment> GetAllByLastWeekAndBlogId(int blogId);
    }
}
