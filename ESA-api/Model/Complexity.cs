using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class Complexity
    {
        public Complexity()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
        }

        public int Id { get; set; }
        public string ComplexityName { get; set; }
        public int ComplexityRange { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
    }
}
