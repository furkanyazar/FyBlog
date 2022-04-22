using Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Notification : IEntity
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationDetail { get; set; }
        public DateTime NotificationDateOf { get; set; } = DateTime.Now;
        public bool NotificationStatus { get; set; } = true;

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
