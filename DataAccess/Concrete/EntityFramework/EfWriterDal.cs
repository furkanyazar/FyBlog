using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfWriterDal : EfEntityRepository<Writer, MvcCoreDbContext>, IWriterDal
    {
        public Writer GetByUserId(int userId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Writers.Include(x => x.User).SingleOrDefault(x => x.UserId == userId);
            }
        }

        public Writer GetByUserEmail(string email)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Writers.Include(x => x.User).SingleOrDefault(x => x.User.UserEmail == email);
            }
        }

        public List<Writer> GetAllWithoutUserId(int userId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Writers.Where(x => x.UserId != userId).Include(x => x.User).ToList();
            }
        }

        public List<Writer> GetAllWithIncludes()
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Writers.Include(x => x.User).ToList();
            }
        }
    }
}
