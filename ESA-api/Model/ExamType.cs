using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class ExamType
    {
        public ExamType()
        {
            Exam = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string ExamTypeName { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
    }
}
