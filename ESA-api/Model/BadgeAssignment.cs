using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class BadgeAssignment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime AssignmentDate { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual FlashcardSet User { get; set; }
    }
}
