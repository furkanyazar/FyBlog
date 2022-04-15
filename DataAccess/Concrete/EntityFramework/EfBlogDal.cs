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
				return context.Blogs.OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
			}
		}

		public Blog GetByIdWithCategoryAndWriter(int id)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Blogs.Where(x => x.BlogId == id).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).SingleOrDefault();
			}
		}

		public List<Blog> GetLatestBlogsWithCount(int count)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Blogs.OrderByDescending(x => x.BlogDateOf).Take(count).ToList();
			}
		}

		public List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId)
		{
			using (var context = new MvcCoreDbContext())
			{
				return context.Blogs.OrderByDescending(x => x.BlogDateOf).Where(x => x.BlogId != blogId && x.CategoryId == categoryId).Take(3).ToList();
			}
		}
	}
}
