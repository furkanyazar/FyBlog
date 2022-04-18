using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepository<Blog, MvcCoreDbContext>, IBlogDal
    {
        public List<Blog> GetAllByCategoryId(int id)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.CategoryId == id).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.WriterId == writerId && x.CategoryId == categoryId).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByDateOf(DateTime dateOf)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogDateOf.Date == dateOf.Date).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.WriterId == writerId && x.BlogDateOf.Date == dateOf.Date).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllBySearchKey(string searchKey)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogTitle.ToLower().Contains(searchKey.ToLower().Trim()) || x.BlogContent.ToLower().Contains(searchKey.ToLower().Trim())).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByWriterId(int id)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.WriterId == id).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllWithCategoryAndWriter()
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public Blog GetById(int id)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogId == id).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).SingleOrDefault();
            }
        }

        public List<Blog> GetLatestsWithCount(int count)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.OrderByDescending(x => x.BlogDateOf).Take(count).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.OrderByDescending(x => x.BlogDateOf).Where(x => x.BlogId != blogId && x.CategoryId == categoryId).Take(3).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }
    }
}
