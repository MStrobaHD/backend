using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EnrolmentDTO
{
    public class UserEnlistedDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public virtual ICollection<CourseEnrolmentEnlistedDTO> CourseEnrolment { get; set; }
    }
}
