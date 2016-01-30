using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class SiteModel
    {
        public IEnumerable<BlogEntry> BlogEntries { get; set; }
    }

    public class BlogEntry
    {
        public BlogEntry()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}