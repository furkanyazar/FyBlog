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

        List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId);

        List<Blog> GetAllByWriterId(int id);

        List<Blog> GetAllByDateOf(DateTime dateOf);

        List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf);

        List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);

        List<Blog> GetLatestsWithCount(int count);

        Blog GetById(int id);
    }
}
