using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IAdminService : IEntityService<Admin>
    {
        Admin GetByUserEmail(string email);
    }
}
