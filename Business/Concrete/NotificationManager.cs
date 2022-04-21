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
    }
}
