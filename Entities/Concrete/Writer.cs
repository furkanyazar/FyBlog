using Core.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }

        public string WriterAbout { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
