using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : EntityManager<User, IUserDal>, IUserService
    {
        public UserManager(IUserDal tdal) : base(tdal)
        {
        }

        public User GetByUserEmail(string email)
        {
            return _tdal.GetByUserEmail(email);
        }

        public User GetByUserId(int userId)
        {
            return _tdal.Get(x => x.UserId == userId);
        }
    }
}
