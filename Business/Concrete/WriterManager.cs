using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class WriterManager : EntityManager<Writer, IWriterDal>, IWriterService
    {
        public WriterManager(IWriterDal tdal) : base(tdal)
        {
        }

        public Writer GetById(int id)
        {
            return _tdal.Get(x => x.WriterId == id);
        }
    }
}
