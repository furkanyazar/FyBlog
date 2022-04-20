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

        public Writer GetByUserId(int userId)
        {
            return _tdal.GetByUserId(userId);
        }

		public Writer GetByUserEmail(string email)
		{
			return _tdal.GetByUserEmail(email);
		}
	}
}
