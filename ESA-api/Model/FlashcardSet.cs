using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class FlashcardSet
    {
        public FlashcardSet()
        {
            BadgeAssignment = new HashSet<BadgeAssignment>();
            Flashcard = new HashSet<Flashcard>();
            FlashcardSetEnrolment = new HashSet<FlashcardSetEnrolment>();
        }

        public int Id { get; set; }
        public string FlashcardSetName { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BadgeAssignment> BadgeAssignment { get; set; }
        public virtual ICollection<Flashcard> Flashcard { get; set; }
        public virtual ICollection<FlashcardSetEnrolment> FlashcardSetEnrolment { get; set; }
    }
}
