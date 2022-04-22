using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatus(int categoryId, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId);

        List<Blog> GetAllByDateOfAndCategoryStatusAndBlogStatus(DateTime dateOf, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf);

        List<Blog> GetAllBySearchKeyAndCategoryStatusAndBlogStatus(string searchKey, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByWriterIdAndCategoryStatusAndBlogStatus(int writerId, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus);

        Blog GetByBlogId(int blogId);

        List<Blog> GetLatestsByUserIdWithCount(int userId, int count);

        List<Blog> GetLatestsByCategoryStatusAndBlogStatusWithCount(int count, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatusWithCountWithoutBlogId(int count, int blogId, int categoryId, bool categoryStatus, bool blogStatus);

        List<Blog> GetAllByUserId(int userId);

        Blog GetLatestByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus);
    }
}
