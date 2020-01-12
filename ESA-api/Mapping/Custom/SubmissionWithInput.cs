using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.Custom
{
    public class SubmissionWithInput
    {
        public string source_code { get; set; }
        public int language_id { get; set; }
        public string stdin { get; set; }
        public int userId { get; set; }
    }
}
