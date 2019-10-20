using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Level
    {
        public Level()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
        }

        public int Id { get; set; }
        public string LevelName { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
    }
}
