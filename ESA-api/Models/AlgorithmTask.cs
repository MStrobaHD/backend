using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class AlgorithmTask
    {
        public AlgorithmTask()
        {
            Verdict = new HashSet<Verdict>();
        }

        public int Id { get; set; }
        public string AlgorithmTaskName { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int ComplexityId { get; set; }
        public int AlgorithmCategoryId { get; set; }
        public int VerificationDataId { get; set; }
        public int RestrictionId { get; set; }
        public int LevelId { get; set; }

        public virtual AlgorithmCategory AlgorithmCategory { get; set; }
        public virtual Complexity Complexity { get; set; }
        public virtual Level Level { get; set; }
        public virtual Restriction Restriction { get; set; }
        public virtual User User { get; set; }
        public virtual VerificationData VerificationData { get; set; }
        public virtual ICollection<Verdict> Verdict { get; set; }
    }
}
