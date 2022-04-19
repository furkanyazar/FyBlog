using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AboutManager : EntityManager<About, IAboutDal>, IAboutService
    {
        public AboutManager(IAboutDal tdal) : base(tdal)
        {
        }

        public List<About> GetAllByStatus(bool status)
        {
            return _tdal.GetAll(x => x.AboutStatus == status).ToList();
        }
    }
}
