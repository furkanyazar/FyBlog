using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class WriterDto : IDto
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserImageUrl { get; set; }
        public string WriterAbout { get; set; }
    }
}
