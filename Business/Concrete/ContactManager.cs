using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
	public class ContactManager : IContactService
	{
		private IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void Add(Contact contact)
		{
			_contactDal.Add(contact);
		}

		public void Delete(Contact contact)
		{
			_contactDal.Delete(contact);
		}

		public List<Contact> GetAll()
		{
			return _contactDal.GetAll();
		}

		public Contact GetById(int id)
		{
			return _contactDal.Get(x => x.ContactId == id);
		}

		public void Update(Contact contact)
		{
			_contactDal.Update(contact);
		}
	}
}
