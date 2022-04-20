using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IWriterDal : IEntityRepository<Writer>
    {
        Writer GetByUserId(int userId);

        Writer GetByUserEmail(string email);
    }
}
