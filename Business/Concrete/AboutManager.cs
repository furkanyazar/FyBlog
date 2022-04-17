using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AboutManager : EntityManager<About, IAboutDal>, IAboutService
    {
        public AboutManager(IAboutDal tdal) : base(tdal)
        {
        }
    }
}
