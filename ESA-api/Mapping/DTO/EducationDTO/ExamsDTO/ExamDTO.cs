using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.ExamsDTO
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public int NumberOfQuestion { get; set; }
        public int TimeForSolve { get; set; }
        public string ExamType { get; set; }
        public int? CourseId { get; set; }
    }
}
