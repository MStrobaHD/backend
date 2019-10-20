using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class ServerAsset
    {
        public int Id { get; set; }
        public string ServerAssetName { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public int? LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual User User { get; set; }
    }
}
