using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class VerificationData
    {
        public VerificationData()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
        }

        public int Id { get; set; }
        public string InputData { get; set; }
        public string OutputData { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
    }
}
