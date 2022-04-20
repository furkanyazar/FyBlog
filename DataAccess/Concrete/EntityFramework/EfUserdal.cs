using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserdal : EfEntityRepository<User, MvcCoreDbContext>, IUserDal
    {
        public User GetByUserEmail(string email)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Users.SingleOrDefault(x => x.UserEmail == email);
            }
        }
    }
}
