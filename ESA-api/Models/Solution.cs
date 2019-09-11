using System;
using System.Collections.Generic;

namespace ESA_api.Models
{
    public partial class Solution
    {
        public Solution()
        {
            Verdict = new HashSet<Verdict>();
        }

        public int Id { get; set; }
        public string SolutionContent { get; set; }

        public virtual ICollection<Verdict> Verdict { get; set; }
    }
}
