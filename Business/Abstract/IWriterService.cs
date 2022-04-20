using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        Writer GetByUserId(int userId);

        Writer GetByUserEmail(string email);
    }
}
