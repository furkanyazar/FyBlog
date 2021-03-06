using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserDto : IDto
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserImageUrl { get; set; }
    }
}
