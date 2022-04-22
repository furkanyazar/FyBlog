using Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        [Key]
        public int MessageId { get; set; }

        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public DateTime MessageDateOf { get; set; } = DateTime.Now;
        public bool MessageStatus { get; set; } = false;

        public int? SenderUserId { get; set; }
        public User SenderUser { get; set; }

        public int? ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; }
    }
}
