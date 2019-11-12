using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentHtml { get; set; }
        public DateTime? CommentDate { get; set; }
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
