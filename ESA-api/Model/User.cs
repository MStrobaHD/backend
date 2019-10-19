using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class User
    {
        public User()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
            CloudAsset = new HashSet<CloudAsset>();
            Course = new HashSet<Course>();
            CourseEnrolment = new HashSet<CourseEnrolment>();
            ExamResult = new HashSet<ExamResult>();
            Experience = new HashSet<Experience>();
            FlashcardSet = new HashSet<FlashcardSet>();
            FlashcardSetEnrolment = new HashSet<FlashcardSetEnrolment>();
            FlashcardSkill = new HashSet<FlashcardSkill>();
            Rating = new HashSet<Rating>();
            ServerAsset = new HashSet<ServerAsset>();
            Verdict = new HashSet<Verdict>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
        public virtual ICollection<CloudAsset> CloudAsset { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseEnrolment> CourseEnrolment { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<Experience> Experience { get; set; }
        public virtual ICollection<FlashcardSet> FlashcardSet { get; set; }
        public virtual ICollection<FlashcardSetEnrolment> FlashcardSetEnrolment { get; set; }
        public virtual ICollection<FlashcardSkill> FlashcardSkill { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
        public virtual ICollection<ServerAsset> ServerAsset { get; set; }
        public virtual ICollection<Verdict> Verdict { get; set; }
    }
}
