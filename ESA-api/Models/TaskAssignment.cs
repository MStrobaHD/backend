using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class TaskAssignment
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? TimeToSolveTask { get; set; }
        public int? IsTaskAccomplished { get; set; }
        public int? AlgorithmTaskId { get; set; }
        public int? StudentId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
        public virtual User Student { get; set; }
    }
}
