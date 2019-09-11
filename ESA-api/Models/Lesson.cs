using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Lesson
    {
        public int Id { get; set; }
        public string LessonTitle { get; set; }
        public int? CloudAssetId { get; set; }
        public int? ServerAssetId { get; set; }
        public int CourseId { get; set; }

        public virtual CloudAsset CloudAsset { get; set; }
        public virtual Course Course { get; set; }
        public virtual ServerAsset ServerAsset { get; set; }
    }
}
