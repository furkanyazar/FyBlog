using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        private INewsletterDal _newsletterDal;

        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void Add(Newsletter newsletter)
        {
            _newsletterDal.Add(newsletter);
        }

        public void Delete(Newsletter newsletter)
        {
            _newsletterDal.Delete(newsletter);
        }

        public List<Newsletter> GetAll()
        {
            return _newsletterDal.GetAll();
        }

        public Newsletter GetById(int id)
        {
            return _newsletterDal.Get(x => x.NewsletterId == id);
        }

        public void Update(Newsletter newsletter)
        {
            _newsletterDal.Update(newsletter);
        }
    }
}
