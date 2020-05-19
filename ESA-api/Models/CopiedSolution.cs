using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class CopiedSolution
    {
        public int Id { get; set; }
        public int? SimilarVerdictId { get; set; }
        public int? AlgorithmTaskId { get; set; }
        public int? VerdictId { get; set; }

        public virtual Verdict Verdict { get; set; }
    }
}
