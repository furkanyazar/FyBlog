﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetAllByCategoryId(int id)
        {
            return _blogDal.GetAll(x => x.CategoryId == id);
        }

        public List<Blog> GetAllByCategoryIdWithCategoryAndWriter(int id)
        {
            return _blogDal.GetAllByCategoryIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetAllByDateOfWithCategoryAndWriter(DateTime dateOf)
        {
            return _blogDal.GetAllByDateOfWithCategoryAndWriter(dateOf);
        }

        public List<Blog> GetAllByWriterIdWithCategoryAndWriter(int id)
        {
            return _blogDal.GetAllByWriterIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetAllWithCategoryAndWriter()
        {
            return _blogDal.GetAllWithCategoryAndWriter();
        }

        public Blog GetById(int id)
        {
            return _blogDal.Get(x => x.BlogId == id);
        }

        public Blog GetByIdWithCategoryAndWriter(int id)
        {
            return _blogDal.GetByIdWithCategoryAndWriter(id);
        }

        public List<Blog> GetLatestBlogsWithCount(int count)
        {
            return _blogDal.GetLatestBlogsWithCount(count);
        }

        public List<Blog> GetSomeByCategoryIdWithoutId(int blogId, int categoryId)
        {
            return _blogDal.GetSomeByCategoryIdWithoutId(blogId, categoryId);
        }

        public void Update(Blog blog)
        {
            _blogDal.Update(blog);
        }
    }
}
