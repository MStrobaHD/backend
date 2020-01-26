using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.CommonDTO.CloudUploadDTO
{
    public class CloudAssetDTO
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
        public int? LessonId { get; set; }
    }
}
