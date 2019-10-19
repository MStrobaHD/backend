using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class FlashcardSetEnrolment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FlashcardSetId { get; set; }

        public virtual FlashcardSet FlashcardSet { get; set; }
        public virtual User User { get; set; }
    }
}
