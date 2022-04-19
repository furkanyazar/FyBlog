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

        public Writer GetByUserIdWithUser(int userId)
        {
            return _tdal.GetByUserIdWithUser(userId);
        }

		public Writer GetByUserEmail(string email)
		{
			return _tdal.GetByUserEmail(email);
		}
	}
}
