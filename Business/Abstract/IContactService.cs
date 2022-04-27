using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IContactService : IEntityService<Contact>
    {
        Contact GetById(int id);

        List<Contact> GetAllByStatus(bool status);
    }
}
