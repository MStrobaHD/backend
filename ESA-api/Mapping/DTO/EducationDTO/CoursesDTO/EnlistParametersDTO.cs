using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.CoursesDTO
{
    public class EnlistParametersDTO
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolmentDate { get; set; }
    }
}
