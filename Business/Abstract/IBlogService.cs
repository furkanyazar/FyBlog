using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetAll();

        List<Blog> GetAllWithCategory();

        Blog GetById(int id);

        void Add(Blog blog);

        void Update(Blog blog);

        void Delete(Blog blog);
    }
}
