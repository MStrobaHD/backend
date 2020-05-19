using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class CourseAssignment
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? GroupId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Group Group { get; set; }
    }
}
