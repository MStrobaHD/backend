using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.ExamsDTO
{
    public class ExamListDTO
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public int NumberOfQuestion { get; set; }
        public int TimeForSolve { get; set; }
    }
}
