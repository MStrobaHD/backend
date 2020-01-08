using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class OrderedBlock
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BlockPosition { get; set; }
        public int ExamId { get; set; }
        public string Definition { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
