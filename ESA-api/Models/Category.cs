using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Category
    {
        public Category()
        {
            Badge = new HashSet<Badge>();
            Course = new HashSet<Course>();
            Experience = new HashSet<Experience>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Badge> Badge { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
    }
}
