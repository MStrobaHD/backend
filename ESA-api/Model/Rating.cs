using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int? Points { get; set; }
        public int? UserId { get; set; }
        public int? AlgorithmTaskId { get; set; }

        public virtual AlgorithmTask AlgorithmTask { get; set; }
        public virtual User User { get; set; }
    }
}
