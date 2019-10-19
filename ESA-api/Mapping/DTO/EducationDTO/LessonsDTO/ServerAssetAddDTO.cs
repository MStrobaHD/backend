using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.LessonsDTO
{
    public class ServerAssetAddDTO
    {
        public string ServerAssetName { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public int? LessonId { get; set; }
    }
}
