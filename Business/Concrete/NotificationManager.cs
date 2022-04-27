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

        public List<Notification> GetAllWithIncludes()
        {
            return _tdal.GetAllWithIncludes();
        }

        public Notification GetById(int id)
        {
            return _tdal.Get(x => x.NotificationId == id);
        }

        public List<Notification> GetLatestsByCount()
        {
            return _tdal.GetLatestsByCount();
        }
    }
}
