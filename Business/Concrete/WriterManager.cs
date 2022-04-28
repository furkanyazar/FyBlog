using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

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

        public List<Writer> GetAllWithoutUserId(int userId)
        {
            return _tdal.GetAllWithoutUserId(userId);
        }

        public List<Writer> GetAllWithIncludes()
        {
            return _tdal.GetAllWithIncludes();
        }
    }
}
