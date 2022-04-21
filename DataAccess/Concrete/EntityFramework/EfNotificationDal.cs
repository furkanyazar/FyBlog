using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNotificationDal : EfEntityRepository<Notification, MvcCoreDbContext>, INotificationDal
    {
        public List<Notification> GetAllWithIncludes()
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Notifications.OrderByDescending(x => x.NotificationDateOf).Include(x => x.NotificationType).ToList();
            }
        }
    }
}
