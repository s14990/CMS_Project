using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class Likes
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual MediaPost Post { get; set; }
        public virtual User User { get; set; }
    }
}
