using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
	public interface IBlogDal : IEntityRepository<Blog>
	{
		List<Blog> GetAllWithCategoryAndWriter();

		List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId);

		List<Blog> GetLatestBlogsWithCount(int count);

		Blog GetByIdWithCategoryAndWriter(int id);
	}
}
