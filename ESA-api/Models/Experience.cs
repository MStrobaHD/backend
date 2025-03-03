﻿using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Experience
    {
        public int Id { get; set; }
        public int ExperiencePoints { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
    }
}
