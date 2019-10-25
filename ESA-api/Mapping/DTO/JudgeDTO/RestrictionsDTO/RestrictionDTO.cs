using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO
{
    public class RestrictionDTO
    {
        public int Id { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public int ElementaryOperationLimit { get; set; }
        public int LinesOfCodeLimit { get; set; }
        public int TimeToSolveLimit { get; set; }
        public int ComplexityOrder { get; set; }
    }
}
