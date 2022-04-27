using Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int ContactId { get; set; }

        public string ContactUserFullName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDateOf { get; set; } = DateTime.Now;
        public bool ContactStatus { get; set; } = false;
    }
}
