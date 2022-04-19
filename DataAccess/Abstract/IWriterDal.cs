using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IWriterDal : IEntityRepository<Writer>
    {
        Writer GetByIdWithUser(int id);

        Writer GetByUserEmailAndUserPassword(string email, string password);
    }
}
