using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        List<Category> GetAllByStatus(bool status);

        Category GetById(int id);

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
