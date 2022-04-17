using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ContactManager : EntityManager<Contact, IContactDal>, IContactService
    {
        public ContactManager(IContactDal tdal) : base(tdal)
        {
        }
    }
}
