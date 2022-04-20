using Core.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public string UserImageUrl { get; set; }
        public bool UserStatus { get; set; } = true;

        public List<Writer> Writers { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
