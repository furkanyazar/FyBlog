using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class NotificationTypeManager : EntityManager<NotificationType, INotificationTypeDal>, INotificationTypeService
    {
        public NotificationTypeManager(INotificationTypeDal tdal) : base(tdal)
        {
        }
    }
}
