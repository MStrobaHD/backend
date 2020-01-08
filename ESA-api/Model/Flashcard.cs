using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class Flashcard
    {
        public Flashcard()
        {
            FlashcardSkill = new HashSet<FlashcardSkill>();
        }

        public int Id { get; set; }
        public string Frontside { get; set; }
        public string Backside { get; set; }
        public string Hint { get; set; }
        public int FlashcardSetId { get; set; }
        public string ImageUrl { get; set; }

        public virtual FlashcardSet FlashcardSet { get; set; }
        public virtual ICollection<FlashcardSkill> FlashcardSkill { get; set; }
    }
}
