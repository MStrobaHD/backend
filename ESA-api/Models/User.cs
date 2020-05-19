using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class User
    {
        public User()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
            BadgeAssignment = new HashSet<BadgeAssignment>();
            CloudAsset = new HashSet<CloudAsset>();
            Course = new HashSet<Course>();
            CourseEnrolment = new HashSet<CourseEnrolment>();
            CourseRating = new HashSet<CourseRating>();
            ExamResult = new HashSet<ExamResult>();
            Experience = new HashSet<Experience>();
            FlashcardSet = new HashSet<FlashcardSet>();
            Group = new HashSet<Group>();
            GroupAssignment = new HashSet<GroupAssignment>();
            Rating = new HashSet<Rating>();
            ServerAsset = new HashSet<ServerAsset>();
            TaskAssignment = new HashSet<TaskAssignment>();
            Verdict = new HashSet<Verdict>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? StudentId { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
        public virtual ICollection<BadgeAssignment> BadgeAssignment { get; set; }
        public virtual ICollection<CloudAsset> CloudAsset { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual ICollection<CourseRating> CourseRating { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<FlashcardSet> FlashcardSet { get; set; }
        public virtual ICollection<Group> Group { get; set; }
        public virtual ICollection<GroupAssignment> GroupAssignment { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<ServerAsset> ServerAsset { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignment { get; set; }
        public virtual ICollection<Verdict> Verdict { get; set; }
    }
}
