using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO
{
    public class VerdictDTO
    {
        public int Id { get; set; }
        public string VerdictName { get; set; }
        public int ElementaryOperation { get; set; }
        public decimal Time { get; set; }
        public decimal Memory { get; set; }
        public int ComplexityOrder { get; set; }
        public int LinesOfCode { get; set; }
        public string Solution { get; set; }
        public int CyclomaticComplexity { get; set; }
        public int NumberOfDecision { get; set; }
        public int NumberOfAssignment { get; set; }
        public int UserId { get; set; }
        public int AlgorithmTaskId { get; set; }
    }
}
