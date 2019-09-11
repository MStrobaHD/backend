using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Course
    {
        public Course()
        {
            CloudAsset = new HashSet<CloudAsset>();
            CourseEnrolment = new HashSet<CourseEnrolment>();
            Exam = new HashSet<Exam>();
            Lesson = new HashSet<Lesson>();
            ServerAsset = new HashSet<ServerAsset>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CourseIconUrl { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CloudAsset> CloudAsset { get; set; }
        public virtual ICollection<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
        public virtual ICollection<ServerAsset> ServerAsset { get; set; }
    }
}
