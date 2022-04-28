using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogImageUrl { get; set; }
        public string BlogThumbnailImageUrl { get; set; }
        public DateTime BlogDateOf { get; set; } = DateTime.Now;

        public object Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public bool BlogStatus { get; set; } = true;

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int WriterId { get; set; }
        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
