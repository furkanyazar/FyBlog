using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

		public void Update(Blog blog)
		{
			_blogDal.Update(blog);
		}
	}
}
