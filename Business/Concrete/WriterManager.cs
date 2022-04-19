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

        public Writer GetByIdWithUser(int id)
        {
            return _tdal.GetByIdWithUser(id);
        }

		public Writer GetByUserEmail(string email)
		{
			return _tdal.GetByUserEmail(email);
		}
	}
}
