using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : EntityManager<Category, ICategoryDal>, ICategoryService
    {
        public CategoryManager(ICategoryDal tdal) : base(tdal)
        {
        }

        public List<Category> GetAllByStatus(bool status)
        {
            return _tdal.GetAll(x => x.CategoryStatus == status);
        }
    }
}
