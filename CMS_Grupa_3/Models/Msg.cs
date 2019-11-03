using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class Msg
    {
        public int MsgId { get; set; }
        public string Text { get; set; }
        public int AutorId { get; set; }
        public int TargetId { get; set; }

        public virtual User Autor { get; set; }
        public virtual User Target { get; set; }
    }
}
