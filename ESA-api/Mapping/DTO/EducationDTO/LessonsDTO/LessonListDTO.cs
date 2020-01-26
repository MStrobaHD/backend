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
        public int? Priority { get; set; }
        public virtual ICollection<CloudAssetAddDTO> CloudAsset { get; set; }
        public virtual ICollection<ServerAssetAddDTO> ServerAsset { get; set; }
    }
}
