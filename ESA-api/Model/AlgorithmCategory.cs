using System;
using System.Collections.Generic;

namespace ESA_api.Model
{
    public partial class AlgorithmCategory
    {
        public AlgorithmCategory()
        {
            AlgorithmTask = new HashSet<AlgorithmTask>();
        }

        public int Id { get; set; }
        public string AlgorithmCategoryName { get; set; }

        public virtual ICollection<AlgorithmTask> AlgorithmTask { get; set; }
    }
}
