using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO
{
    public class AlgorithmTaskAddDTO
    {
        public string AlgorithmTaskName { get; set; }
        public string Description { get; set; }
        public decimal TimeLimit { get; set; }
        public int? MemoryLimit { get; set; }
        public int? ElementaryOperationLimit { get; set; }
        public int? LinesOfCodeLimit { get; set; }
        public int? TimeToSolveLimit { get; set; }
        public int? ComplexityOrder { get; set; }
        public int LevelId { get; set; }
        public int AlgorithmCategoryId { get; set; }
        public int ComplexityId { get; set; }
        public int UserId { get; set; }
    }
}
