﻿using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class CourseRating
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
