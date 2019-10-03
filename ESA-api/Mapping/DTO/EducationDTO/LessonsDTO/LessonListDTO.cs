using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.LessonsDTO
{
    public class LessonListDTO
    {
        public int Id { get; set; }
        public string LessonTitle { get; set; }
        public int? CloudAssetId { get; set; }
        public int? ServerAssetId { get; set; }
    }
}
