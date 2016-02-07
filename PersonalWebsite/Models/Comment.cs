using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public Comment()
            {
                //this.Comments = new HashSet<Comment>();
            }
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; } 
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string UpdateReason { get; set; }
        public bool MarkForDeletion { get; set; } 
        public virtual ApplicationUser Author { get; set; }
    }
}