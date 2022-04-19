using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserdal : EfEntityRepository<User, MvcCoreDbContext>, IUserDal
    {
    }
}
