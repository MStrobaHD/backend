using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class CFG
    {
        public CFG(string methodName, List<Nodes> nodes, List<Edges> edges)
        {
            this.methodName = methodName;
            this.nodes = nodes;
            this.edges = edges;
        }

        public string methodName { get; set; }
        public List<Nodes> nodes { get; set; }
        public List<Edges> edges { get; set; }
    }
}
