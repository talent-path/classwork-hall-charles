using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBlog.Models
{
    public class Comment
    {
        [Column("Id")]
        public int CommentId { get; set; }
        [Required]
        public BlogUser Author { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int ParentPost { get; set; }
    }
}
