using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class ExamResult
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public int Points { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual User User { get; set; }
    }
}
