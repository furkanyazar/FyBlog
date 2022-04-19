using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserLoginDto : IDto
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
