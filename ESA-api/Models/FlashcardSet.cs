using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class FlashcardSet
    {
        public FlashcardSet()
        {
            Flashcard = new HashSet<Flashcard>();
        }

        public int Id { get; set; }
        public string FlashcardSetName { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Flashcard> Flashcard { get; set; }
    }
}
