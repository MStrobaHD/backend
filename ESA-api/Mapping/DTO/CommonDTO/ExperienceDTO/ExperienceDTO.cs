using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.CommonDTO.ExperienceDTO
{
    public class ExperienceDTO
    {
        public int Id { get; set; }
        public int ExperiencePoints { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
