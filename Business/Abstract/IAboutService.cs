using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IAboutService : IEntityService<About>
    {
        List<About> GetAllByStatus(bool status);
    }
}
