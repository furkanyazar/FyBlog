using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfWriterDal : EfEntityRepository<Writer, MvcCoreDbContext>, IWriterDal
	{
		public Writer GetByIdWithUser(int id)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Writers.Include(x => x.User).SingleOrDefault(x => x.UserId == id);
			}
		}

		public Writer GetByUserEmailAndUserPassword(string email, string password)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Writers.Include(x => x.User).SingleOrDefault(x => x.User.UserEmail == email && x.User.UserPassword == password);
			}
		}
	}
}
