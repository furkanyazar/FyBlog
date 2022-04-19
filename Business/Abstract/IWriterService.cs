using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        Writer GetByIdWithUser(int id);

        Writer GetByUserEmail(string email);
    }
}
