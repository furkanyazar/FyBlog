using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        Writer GetByUserId(int userId);

        Writer GetByUserEmail(string email);

        List<Writer> GetAllWithoutUserId(int userId);
    }
}
