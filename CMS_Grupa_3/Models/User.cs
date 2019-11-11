using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class User
    {
        public User()
        {
            Comment = new HashSet<Comment>();
            FriendList = new HashSet<FriendList>();
            MediaFile = new HashSet<MediaFile>();
            MediaPost = new HashSet<MediaPost>();
            MsgAutor = new HashSet<Msg>();
            MsgTarget = new HashSet<Msg>();
            Sesn = new HashSet<Sesn>();
            UsersInFl = new HashSet<UsersInFl>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRank { get; set; }
        public string UserStatus { get; set; }
        public bool? UserConfirmed { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<FriendList> FriendList { get; set; }
        public virtual ICollection<MediaFile> MediaFile { get; set; }
        public virtual ICollection<MediaPost> MediaPost { get; set; }
        public virtual ICollection<Msg> MsgAutor { get; set; }
        public virtual ICollection<Msg> MsgTarget { get; set; }
        public virtual ICollection<Sesn> Sesn { get; set; }
        public virtual ICollection<UsersInFl> UsersInFl { get; set; }
    }
}
