﻿using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class CourseEnrolment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolmentDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
