using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NotificationManager : EntityManager<Notification, INotificationDal>, INotificationService
    {
        public NotificationManager(INotificationDal tdal) : base(tdal)
        {
        }
    }
}
