using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class NotificationManager : EntityManager<Notification, INotificationDal>, INotificationService
    {
        public NotificationManager(INotificationDal tdal) : base(tdal)
        {
        }

        public List<Notification> GetLatestsByCount(int count = 0)
        {
            return _tdal.GetLatestsByCount(count);
        }
    }
}
