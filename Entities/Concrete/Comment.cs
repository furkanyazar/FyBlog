using Core.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentContent { get; set; }
        public DateTime CommentDateOf { get; set; } = DateTime.Now;
        public bool CommentStatus { get; set; } = true;

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
