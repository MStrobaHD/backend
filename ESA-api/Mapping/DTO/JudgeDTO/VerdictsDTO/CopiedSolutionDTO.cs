using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO
{
    public class CopiedSolutionDTO
    {
        public int? SimilarVerdictId { get; set; }
        public int? AlgorithmTaskId { get; set; }
        public int? VerdictId { get; set; }
    }
}
