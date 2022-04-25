using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAdminDal : IEntityRepository<Admin>
    {
        Admin GetByUserEmail(string email);

        Admin GetByUserId(int userId);
    }
}
