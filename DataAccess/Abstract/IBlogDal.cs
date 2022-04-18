using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        List<Blog> GetAllWithCategoryAndWriter();

        List<Blog> GetAllBySearchKey(string searchKey);

        List<Blog> GetAllByCategoryId(int id);

        List<Blog> GetAllByWriterId(int id);

        List<Blog> GetAllByDateOf(DateTime dateOf);

        List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);

        List<Blog> GetLatestsWithCount(int count);

        Blog GetById(int id);
    }
}
