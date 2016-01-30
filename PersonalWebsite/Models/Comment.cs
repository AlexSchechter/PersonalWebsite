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
                this.Comments = new HashSet<Comment>();
            }
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; } //from AspNetUsers as user needs to log in
        public string EditorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string UpdateReason { get; set; }
        public int ParentCommentId { get; set; }
        public bool MarkForDeletion { get; set; } 

        public virtual BlogEntry Post { get; set; } //why above not virtual but this virtual?
        public virtual ApplicationUser Author { get; set; }
        public virtual ApplicationUser Editor { get; set; }
        public virtual Comment ParentComment { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } //virtual to allow for lazy loading

    }
}