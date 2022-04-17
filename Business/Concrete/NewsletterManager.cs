using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NewsletterManager : EntityManager<Newsletter, INewsletterDal>, INewsletterService
    {
        public NewsletterManager(INewsletterDal tdal) : base(tdal)
        {
        }
    }
}
