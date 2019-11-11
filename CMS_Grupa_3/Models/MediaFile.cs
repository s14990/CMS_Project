using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class MediaFile
    {
        public MediaFile()
        {
            MediaPost = new HashSet<MediaPost>();
        }

        public int FileId { get; set; }
        public string MediaType { get; set; }
        public string MediaName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileLink { get; set; }
        public string MediaDescription { get; set; }
        public DateTime? MediaDate { get; set; }
        public int UploaderId { get; set; }

        public virtual User Uploader { get; set; }
        public virtual ICollection<MediaPost> MediaPost { get; set; }
    }
}
