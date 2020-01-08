using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class Nodes
    {
        public Nodes(string id, string label)
        {
            Id = id;
            Label = label;
        }

        public string Id { get; set; }
        public string Label { get; set; }
    }
}
