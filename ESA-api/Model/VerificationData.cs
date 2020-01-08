using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class VerificationData
    {
        public int Id { get; set; }
        public string InputData { get; set; }
        public string OutputData { get; set; }
        public int AlgorithmTaskId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
    }
}
