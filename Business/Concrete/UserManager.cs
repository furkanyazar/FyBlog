using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User GetByEmailAndPassword(User user)
        {
            return _userDal.GetByEmailAndPassword(user);
        }

        public User GetById(int id)
        {
            return _userDal.Get(x => x.UserId == id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
