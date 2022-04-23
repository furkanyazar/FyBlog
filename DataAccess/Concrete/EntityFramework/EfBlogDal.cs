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
        public List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatus(int categoryId, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.CategoryId == categoryId && x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.WriterId == writerId && x.CategoryId == categoryId && x.Category.CategoryStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByDateOfAndCategoryStatusAndBlogStatus(DateTime dateOf, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogDateOf.Date == dateOf.Date && x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.WriterId == writerId && x.BlogDateOf.Date == dateOf.Date && x.Category.CategoryStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllBySearchKeyAndCategoryStatusAndBlogStatus(string searchKey, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogTitle.ToLower().Contains(searchKey.ToLower().Trim()) || x.BlogContent.ToLower().Contains(searchKey.ToLower().Trim()) && x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByWriterIdAndCategoryStatusAndBlogStatus(int writerId, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.Writer.WriterId == writerId && x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogStatus == blogStatus && x.Category.CategoryStatus == categoryStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public Blog GetByBlogId(int blogId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.BlogId == blogId).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).SingleOrDefault();
            }
        }

        public List<Blog> GetLatestsByUserIdWithCount(int userId, int count)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.Writer.UserId == userId && x.Category.CategoryStatus).OrderByDescending(x => x.BlogDateOf).Take(count).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetLatestsByCategoryStatusAndBlogStatusWithCount(int count, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Take(count).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatusWithCountWithoutBlogId(int count, int blogId, int categoryId, bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.OrderByDescending(x => x.BlogDateOf).Where(x => x.BlogId != blogId && x.CategoryId == categoryId && x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).Take(count).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public List<Blog> GetAllByUserId(int userId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.Writer.UserId == userId && x.Category.CategoryStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).ToList();
            }
        }

        public Blog GetLatestByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Blogs.Where(x => x.Category.CategoryStatus == categoryStatus && x.BlogStatus == blogStatus).OrderByDescending(x => x.BlogDateOf).Include(x => x.Category).Include(x => x.Writer).Include(x => x.Writer.User).Take(1).SingleOrDefault();
            }
        }
    }
}
