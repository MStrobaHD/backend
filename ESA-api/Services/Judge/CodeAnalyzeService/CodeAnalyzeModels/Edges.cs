using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class Edges
    {
        public Edges(string id, string source, string target, string label)
        {
            Id = id;
            Source = source;
            Target = target;
            Label = label;
        }

        public string Id { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public string Label { get; set; }

    }
}
