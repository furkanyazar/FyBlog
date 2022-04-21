using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface INotificationDal : IEntityRepository<Notification>
    {
        List<Notification> GetLatestsByCount(int count);
    }
}
