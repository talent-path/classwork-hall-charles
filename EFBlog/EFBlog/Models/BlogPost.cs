using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    public class BlogPost
    {
        [Column("Id")]
        public int BlogPostId { get; set; }

        [Required]
        public BlogUser Author { get; set; }

        [Required]
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
