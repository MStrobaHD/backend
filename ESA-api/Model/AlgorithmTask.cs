using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class AlgorithmTask
    {
        public AlgorithmTask()
        {
            Rating = new HashSet<Rating>();
            Verdict = new HashSet<Verdict>();
            VerificationData = new HashSet<VerificationData>();
        }

        public int Id { get; set; }
        public string AlgorithmTaskName { get; set; }
        public string Description { get; set; }
        public decimal TimeLimit { get; set; }
        public int? MemoryLimit { get; set; }
        public int? ElementaryOperationLimit { get; set; }
        public int? LinesOfCodeLimit { get; set; }
        public int? TimeToSolveLimit { get; set; }
        public int? ComplexityOrder { get; set; }
        public int LevelId { get; set; }
        public int AlgorithmCategoryId { get; set; }
        public int ComplexityId { get; set; }
        public int UserId { get; set; }

        public virtual AlgorithmCategory AlgorithmCategory { get; set; }
        public virtual Complexity Complexity { get; set; }
        public virtual Level Level { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<Verdict> Verdict { get; set; }
        public virtual ICollection<VerificationData> VerificationData { get; set; }
    }
}
