using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
	public interface IBlogDal : IEntityRepository<Blog>
	{
		List<Blog> GetAllWithCategoryAndWriter();

		Blog GetByIdWithCategoryAndWriter(int id);
	}
}
