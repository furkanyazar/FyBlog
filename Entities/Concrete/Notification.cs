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
        public DateTime NotificationDateOf { get; set; }
        public bool NotificationStatus { get; set; }

        public int NotificationTypeId { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
