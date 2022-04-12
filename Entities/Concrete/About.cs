using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutId { get; set; }

        public string AboutText { get; set; }
        public string AboutImageUrl { get; set; }
        public bool AboutStatus { get; set; } = true;
    }
}
