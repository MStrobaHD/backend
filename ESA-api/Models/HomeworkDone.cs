using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class HomeworkDone
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public short? TaskAssignmentId { get; set; }
    }
}
