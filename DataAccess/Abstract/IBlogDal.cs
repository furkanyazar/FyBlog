using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<Blog> GetAllWithCategoryAndWriter();

        List<Blog> GetAllByCategoryIdWithCategoryAndWriter(int id);

        List<Blog> GetAllByWriterIdWithCategoryAndWriter(int id);

        List<Blog> GetAllByDateOfWithCategoryAndWriter(DateTime dateOf);

        List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);

        List<Blog> GetLatestBlogsWithCount(int count);

        Blog GetByIdWithCategoryAndWriter(int id);
    }
}
