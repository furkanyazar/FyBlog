using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Newsletter : IEntity
    {
        public int NewsletterId { get; set; }
        public string NewsletterEmail { get; set; }
        public bool NewsletterStatus { get; set; } = true;
    }
}
