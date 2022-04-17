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

        public List<Blog> GetAllByCategoryId(int id)
        {
            return _tdal.GetAll(x => x.CategoryId == id);
        }

        public List<Blog> GetAllByCategoryIdWithCategoryAndWriter(int id)
        {
            return _tdal.GetAllByCategoryIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetAllByDateOfWithCategoryAndWriter(DateTime dateOf)
        {
            return _tdal.GetAllByDateOfWithCategoryAndWriter(dateOf);
        }

        public List<Blog> GetAllBySearchKey(string searchKey)
        {
            return _tdal.GetAllBySearchKey(searchKey);
        }

        public List<Blog> GetAllByWriterIdWithCategoryAndWriter(int id)
        {
            return _tdal.GetAllByWriterIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetAllWithCategoryAndWriter()
        {
            return _tdal.GetAllWithCategoryAndWriter();
        }

        public Blog GetByIdWithCategoryAndWriter(int id)
        {
            return _tdal.GetByIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetLatestBlogsWithCount(int count)
        {
            return _tdal.GetLatestBlogsWithCount(count);
        }

        public List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId)
        {
            return _tdal.GetSomeByCategoryIdWithoutId(blogId, categoryId);
        }
    }
}
