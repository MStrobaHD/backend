using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class Restriction
    {
        public Restriction()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
        }

        public int Id { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int ElementaryOperationLimit { get; set; }
        public int LinesOfCodeLimit { get; set; }
        public int TimeToSolveLimit { get; set; }
        public int ComplexityOrder { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
    }
}
