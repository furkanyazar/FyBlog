using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IWriterDal : IEntityRepository<Writer>
    {
        Writer GetByUserId(int userId);

        Writer GetByUserEmail(string email);

        List<Writer> GetAllWithoutUserId(int userId);

        List<Writer> GetAllWithIncludes();
    }
}
