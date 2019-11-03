using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class Video
    {
        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoLink { get; set; }
        public string Format { get; set; }
    }
}
