using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class MediaPost
    {
        public int PostId { get; set; }
        public string PostHtml { get; set; }
        public DateTime PostDate { get; set; }
        public int MediaFileId { get; set; }
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
        public virtual MediaFile MediaFile { get; set; }
    }
}
