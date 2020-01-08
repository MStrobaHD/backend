using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels
{
    public class CFG
    {
        public CFG(List<Nodes> nodes, List<Edges> edges)
        {
            this.nodes = nodes;
            this.edges = edges;
        }

        public List<Nodes> nodes { get; set; }
        public List<Edges> edges { get; set; }
    }
}
