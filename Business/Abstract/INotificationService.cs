using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INotificationService : IEntityService<Notification>
    {
        List<Notification> GetLatestsByCount(int count = 0);
    }
}
