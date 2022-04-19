using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserRegisterDto : IDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
