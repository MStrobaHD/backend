using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string QuestionContent { get; set; }
        public string Answer { get; set; }
        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
