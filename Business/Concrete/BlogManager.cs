using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BlogManager : EntityManager<Blog, IBlogDal>, IBlogService
    {
        public BlogManager(IBlogDal tdal) : base(tdal)
        {
        }

        public List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatus(int categoryId, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllByCategoryIdAndCategoryStatusAndBlogStatus(categoryId, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId)
        {
            return _tdal.GetAllByCategoryIdAndWriterId(writerId, categoryId);
        }

        public List<Blog> GetAllByDateOfAndCategoryStatusAndBlogStatus(DateTime dateOf, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllByDateOfAndCategoryStatusAndBlogStatus(dateOf, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf)
        {
            return _tdal.GetAllByDateOfAndWriterId(writerId, dateOf);
        }

        public List<Blog> GetAllBySearchKeyAndCategoryStatusAndBlogStatus(string searchKey, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllBySearchKeyAndCategoryStatusAndBlogStatus(searchKey, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByWriterIdAndCategoryStatusAndBlogStatus(int writerId, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllByWriterIdAndCategoryStatusAndBlogStatus(writerId, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllByCategoryStatusAndBlogStatus(categoryStatus, blogStatus);
        }

        public Blog GetByBlogId(int blogId)
        {
            return _tdal.GetByBlogId(blogId);
        }

        public List<Blog> GetLatestsByUserIdWithCount(int userId, int count)
        {
            return _tdal.GetLatestsByUserIdWithCount(userId, count);
        }

        public List<Blog> GetLatestsByCategoryStatusAndBlogStatusWithCount(int count, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetLatestsByCategoryStatusAndBlogStatusWithCount(count, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByCategoryIdAndCategoryStatusAndBlogStatusWithCountWithoutBlogId(int count, int blogId, int categoryId, bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetAllByCategoryIdAndCategoryStatusAndBlogStatusWithCountWithoutBlogId(count, blogId, categoryId, categoryStatus, blogStatus);
        }

        public List<Blog> GetAllByUserId(int userId)
        {
            return _tdal.GetAllByUserId(userId);
        }

        public Blog GetLatestByCategoryStatusAndBlogStatus(bool categoryStatus, bool blogStatus)
        {
            return _tdal.GetLatestByCategoryStatusAndBlogStatus(categoryStatus, blogStatus);
        }
    }
}
