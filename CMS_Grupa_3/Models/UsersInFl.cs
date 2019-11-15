using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class UsersInFl
    {
        public int UflId { get; set; }
        public int FlId { get; set; }
        public int UserId { get; set; }
        public int FlStatus { get; set; }

        public virtual FriendList Fl { get; set; }
        public virtual User User { get; set; }
    }
}
