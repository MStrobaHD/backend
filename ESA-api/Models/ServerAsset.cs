using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class ServerAsset
    {
        public ServerAsset()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string ServerAssetName { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
