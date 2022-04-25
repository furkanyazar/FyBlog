using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepository<Admin, MvcCoreDbContext>, IAdminDal
    {
        public Admin GetByUserEmail(string email)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Admins.Include(x => x.User).SingleOrDefault(x => x.User.UserEmail == email);
            }
        }

        public Admin GetByUserId(int userId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Admins.Include(x => x.User).SingleOrDefault(x => x.UserId == userId);
            }
        }
    }
}
