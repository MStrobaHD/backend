using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.Custom
{
    public class JsonCompilationResult
    {
        public int language_id { get; set; }
        public string stdout { get; set; }
        public string status_id { get; set; }
        //public string time { get; set; }
        //public string memory { get; set; }
        public string stderr { get; set; }
        public string compile_output { get; set; }
        public Status status { get; set; }
    }
}
