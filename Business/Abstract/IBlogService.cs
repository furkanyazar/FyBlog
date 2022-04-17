using Core.Business;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService : IEntityService<Blog>
    {
        List<Blog> GetAllWithCategoryAndWriter();

        List<Blog> GetAllBySearchKey(string searchKey);

        List<Blog> GetAllByCategoryId(int id);

        List<Blog> GetAllByCategoryIdWithCategoryAndWriter(int id);

        List<Blog> GetAllByWriterIdWithCategoryAndWriter(int id);

        List<Blog> GetAllByDateOfWithCategoryAndWriter(DateTime dateOf);

        List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);

        List<Blog> GetLatestBlogsWithCount(int count);

        Blog GetByIdWithCategoryAndWriter(int id);
    }
}
