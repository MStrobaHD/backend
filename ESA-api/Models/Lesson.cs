using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            CloudAsset = new HashSet<CloudAsset>();
            ServerAsset = new HashSet<ServerAsset>();
        }

        public int Id { get; set; }
        public string LessonTitle { get; set; }
        public int CourseId { get; set; }
        public int? Priority { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CloudAsset> CloudAsset { get; set; }
        public virtual ICollection<ServerAsset> ServerAsset { get; set; }
    }
}
