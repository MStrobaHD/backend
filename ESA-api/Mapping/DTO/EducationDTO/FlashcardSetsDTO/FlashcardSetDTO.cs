using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.FlashcardSetsDTO
{
    public class FlashcardSetDTO
    {
        public int Id { get; set; }
        public string FlashcardSetName { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}
