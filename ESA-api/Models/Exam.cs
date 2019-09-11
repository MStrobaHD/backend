using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Exam
    {
        public Exam()
        {
            ExamResult = new HashSet<ExamResult>();
            MultiSelectQuestion = new HashSet<MultiSelectQuestion>();
            OrderedBlock = new HashSet<OrderedBlock>();
        }

        public int Id { get; set; }
        public string ExamName { get; set; }
        public int NumberOfQuestion { get; set; }
        public int TimeForSolve { get; set; }
        public int ExamTypeId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual ExamType ExamType { get; set; }
        public virtual Question Question { get; set; }
        public virtual ICollection<ExamResult> ExamResult { get; set; }
        public virtual ICollection<MultiSelectQuestion> MultiSelectQuestion { get; set; }
        public virtual ICollection<OrderedBlock> OrderedBlock { get; set; }
    }
}
