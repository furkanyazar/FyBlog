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
        public List<Blog> GetAllWithCategory()
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }
    }
}
