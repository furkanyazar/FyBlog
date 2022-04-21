using Core.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class NotificationType : IEntity
    {
        [Key]
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public string NotificationTypeSymbol { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}
