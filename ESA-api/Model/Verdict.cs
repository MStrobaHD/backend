using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class Verdict
    {
        public int Id { get; set; }
        public string VerdictName { get; set; }
        public int ElementaryOperation { get; set; }
        public int Time { get; set; }
        public int Memory { get; set; }
        public int ComplexityOrder { get; set; }
        public int TimeToSolve { get; set; }
        public int LinesOfCode { get; set; }
        public int UserId { get; set; }
        public int AlgorithmTaskId { get; set; }
        public int SolutionId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
        public virtual Solution Solution { get; set; }
        public virtual User User { get; set; }
    }
}
