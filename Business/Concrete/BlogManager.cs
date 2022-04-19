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

        public List<Blog> GetAllByCategoryId(int categoryId)
        {
            return _tdal.GetAllByCategoryId(categoryId);
        }

        public List<Blog> GetAllByCategoryIdAndWriterId(int writerId, int categoryId)
        {
            return _tdal.GetAllByCategoryIdAndWriterId(writerId, categoryId);
        }

        public List<Blog> GetAllByDateOf(DateTime dateOf)
        {
            return _tdal.GetAllByDateOf(dateOf);
        }

        public List<Blog> GetAllByDateOfAndWriterId(int writerId, DateTime dateOf)
        {
            return _tdal.GetAllByDateOfAndWriterId(writerId, dateOf);
        }

        public List<Blog> GetAllBySearchKey(string searchKey)
        {
            return _tdal.GetAllBySearchKey(searchKey);
        }

        public List<Blog> GetAllByUserId(int userId)
        {
            return _tdal.GetAllByUserId(userId);
        }

        public List<Blog> GetAllWithCategoryAndWriter()
        {
            return _tdal.GetAllWithCategoryAndWriter();
        }

        public Blog GetByBlogId(int blogId)
        {
            return _tdal.GetByBlogId(blogId);
        }

        public List<Blog> GetLatestsByWriterIdWithCount(int writerId, int count)
        {
            return _tdal.GetLatestsByWriterIdWithCount(writerId, count);
        }

        public List<Blog> GetLatestsWithCount(int count)
        {
            return _tdal.GetLatestsWithCount(count);
        }

        public List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId)
        {
            return _tdal.GetSomeByCategoryIdWithoutId(blogId, categoryId);
        }
    }
}
