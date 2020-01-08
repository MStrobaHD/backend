using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class MultiSelectQuestion
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
