using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class TaskToGroupAssignment
    {
        public int Id { get; set; }
        public int? AlgorithmTaskId { get; set; }
        public int? GroupId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
        public virtual Group Group { get; set; }
    }
}
