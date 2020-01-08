using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO
{
    public class ExamResultAddDTO
    {
        public string Mark { get; set; }
        public int Points { get; set; }
        public int MaxPoints { get; set; }
        public int Percentage { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
    }
}
