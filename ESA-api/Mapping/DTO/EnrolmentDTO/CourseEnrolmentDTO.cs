using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EnrolmentDTO
{
    public class CourseEnrolmentEnlistedDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public virtual CourseEnlistedDTO Course { get; set; }
    }
}
