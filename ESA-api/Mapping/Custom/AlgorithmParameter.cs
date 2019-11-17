using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.Custom
{
    public class AlgorithmParameter
    {
        public int Id { get; set; }
        public string AlgorithTaskName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Complexity { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string CategoryName { get; set; }
        public string LevelName { get; set; }
    }
}
