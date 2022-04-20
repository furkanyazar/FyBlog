using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfWriterDal : EfEntityRepository<Writer, MvcCoreDbContext>, IWriterDal
	{
		public Writer GetByUserId(int userId)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Writers.Include(x => x.User).SingleOrDefault(x => x.UserId == userId);
			}
		}

		public Writer GetByUserEmail(string email)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Writers.Include(x => x.User).SingleOrDefault(x => x.User.UserEmail == email);
			}
		}
	}
}
