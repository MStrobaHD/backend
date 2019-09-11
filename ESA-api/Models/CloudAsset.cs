using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class CloudAsset
    {
        public CloudAsset()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string AssetName { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
