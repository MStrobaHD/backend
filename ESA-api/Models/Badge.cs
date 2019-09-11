using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Badge
    {
        public Badge()
        {
            BadgeAssignment = new HashSet<BadgeAssignment>();
        }

        public int Id { get; set; }
        public string BadgeName { get; set; }
        public int ExperiencePoints { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<BadgeAssignment> BadgeAssignment { get; set; }
    }
}
