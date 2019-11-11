using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class FriendList
    {
        public FriendList()
        {
            UsersInFl = new HashSet<UsersInFl>();
        }

        public int FlId { get; set; }
        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<UsersInFl> UsersInFl { get; set; }
    }
}
