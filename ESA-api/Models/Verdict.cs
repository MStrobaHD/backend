using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Verdict
    {
        public int Id { get; set; }
        public string VerdictName { get; set; }
        public int ElementaryOperation { get; set; }
        public decimal Time { get; set; }
        public decimal Memory { get; set; }
        public int ComplexityOrder { get; set; }
        public int LinesOfCode { get; set; }
        public string Solution { get; set; }
        public int? CyclomaticComplexity { get; set; }
        public int? NumberOfDecision { get; set; }
        public int? NumberOfAssignment { get; set; }
        public int UserId { get; set; }
        public int AlgorithmTaskId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
        public virtual User User { get; set; }
    }
}
