using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Group
    {
        public Group()
        {
            CourseAssignment = new HashSet<CourseAssignment>();
            GroupAssignment = new HashSet<GroupAssignment>();
            TaskToGroupAssignment = new HashSet<TaskToGroupAssignment>();
        }

        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupType { get; set; }
        public int? TeacherId { get; set; }

        public virtual User Teacher { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignment { get; set; }
        public virtual ICollection<GroupAssignment> GroupAssignment { get; set; }
        public virtual ICollection<TaskToGroupAssignment> TaskToGroupAssignment { get; set; }
    }
}
