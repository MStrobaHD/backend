using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO
{
    public class VerdictAddDTO
    {
        public string VerdictName { get; set; }
        public string AlgorithmTaskName { get; set; }
        public int ElementaryOperation { get; set; }
        public decimal Time { get; set; }
        public int Memory { get; set; }
        public int ComplexityOrder { get; set; }
        public int TimeToSolve { get; set; }
        public int LinesOfCode { get; set; }
        public string Solution { get; set; }
        public int UserId { get; set; }
        public int AlgorithmTaskId { get; set; }
    }
}
