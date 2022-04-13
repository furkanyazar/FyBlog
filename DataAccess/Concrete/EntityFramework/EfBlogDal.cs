using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfBlogDal : EfEntityRepository<Blog, MvcCoreDbContext>, IBlogDal
	{
		public List<Blog> GetAllWithCategoryAndWriter()
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Blogs.Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
			}
		}

		public Blog GetByIdWithCategoryAndWriter(int id)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Blogs.Where(x => x.BlogId == id).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).SingleOrDefault();
			}
		}
	}
}
