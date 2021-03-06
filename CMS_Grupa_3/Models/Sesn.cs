﻿using System;
using System.Collections.Generic;

namespace CMS_Grupa_3.Models
{
    public partial class Sesn
    {
        public int SesnId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual User User { get; set; }
    }
}
