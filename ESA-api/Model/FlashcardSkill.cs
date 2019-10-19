using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class FlashcardSkill
    {
        public int Id { get; set; }
        public int Skill { get; set; }
        public int IsLearned { get; set; }
        public int FlashcardId { get; set; }
        public int UserId { get; set; }

        public virtual Flashcard Flashcard { get; set; }
        public virtual User User { get; set; }
    }
}
