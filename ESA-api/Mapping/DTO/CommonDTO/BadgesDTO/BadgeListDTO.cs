using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.CommonDTO.BadgesDTO
{
    public class BadgeListDTO
    {
        public int Id { get; set; }
        public string BadgeName { get; set; }
        public int ExperiencePoints { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
