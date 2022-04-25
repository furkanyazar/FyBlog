using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class AdminManager : EntityManager<Admin, IAdminDal>, IAdminService
    {
        public AdminManager(IAdminDal tdal) : base(tdal)
        {
        }

        public Admin GetByUserEmail(string email)
        {
            return _tdal.GetByUserEmail(email);
        }

        public Admin GetByUserId(int userId)
        {
            return _tdal.GetByUserId(userId);
        }
    }
}
