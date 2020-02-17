using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.FlashcardsDTO
{
    public class FlashcardAddDTO
    {
        public string Frontside { get; set; }
        public string Backside { get; set; }
        public string Hint { get; set; }
        public int FlashcardSetId { get; set; }
        public string ImageUrl { get; set; }
    }
}
