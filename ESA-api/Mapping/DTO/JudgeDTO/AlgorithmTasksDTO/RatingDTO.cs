using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO
{
    public class RatingDTO
    {
        public int? Points { get; set; }
        public int? UserId { get; set; }
        public int? AlgorithmTaskId { get; set; }
    }
}
