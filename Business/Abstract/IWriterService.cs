using Core.Business;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWriterService : IEntityService<Writer>
    {
        Writer GetById(int id);
    }
}
