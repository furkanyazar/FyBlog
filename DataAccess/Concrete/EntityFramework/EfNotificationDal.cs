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
        public List<Notification> GetLatestsByCount()
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Notifications.Where(x => x.NotificationStatus).OrderByDescending(x => x.NotificationDateOf).Include(x => x.NotificationType).ToList();
            }
        }
    }
}
