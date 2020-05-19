using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.GroupsDTO
{
    public class GroupAddDTO
    {
        public string GroupName { get; set; }
        public string GroupType { get; set; }
        public int? TeacherId { get; set; }
    }
}
