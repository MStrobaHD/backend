﻿using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class FlashcardSkill
    {
        public int Id { get; set; }
        public int Skill { get; set; }
        public int IsLearned { get; set; }
        public int FlashcardId { get; set; }

        public virtual Flashcard Flashcard { get; set; }
    }
}
