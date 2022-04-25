using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService : IEntityService<Category>
    {
        List<Category> GetAllByStatus(bool status);

        Category GetById(int id);
    }
}
