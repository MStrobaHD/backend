using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class CloudAsset
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
        public int? LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual User User { get; set; }
    }
}
