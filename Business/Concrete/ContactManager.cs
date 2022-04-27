using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ContactManager : EntityManager<Contact, IContactDal>, IContactService
    {
        public ContactManager(IContactDal tdal) : base(tdal)
        {
        }

        public List<Contact> GetAllByStatus(bool status)
        {
            return _tdal.GetAll(x => x.ContactStatus == status);
        }

        public Contact GetById(int id)
        {
            return _tdal.Get(x => x.ContactId == id);
        }
    }
}
