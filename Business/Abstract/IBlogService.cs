using Core.Business;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IEntityService<Blog>
    {
        List<Blog> GetAllByCategoryId(int categoryId);

        List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId);

        List<Blog> GetAllByDateOf(DateTime dateOf);

        List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf);

        List<Blog> GetAllBySearchKey(string searchKey);

        List<Blog> GetAllByUserId(int userId);

        List<Blog> GetAllWithCategoryAndWriter();

        Blog GetByBlogId(int blogId);

        List<Blog> GetLatestsByWriterIdWithCount(int writerId, int count);

        List<Blog> GetLatestsWithCount(int count);

        List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);
    }
}
