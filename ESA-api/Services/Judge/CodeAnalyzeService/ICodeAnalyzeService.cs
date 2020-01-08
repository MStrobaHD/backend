using ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CodeAnalyzeService
{
    public interface ICodeAnalyzeService
    {
        List<Node> CreateControlFlowGraph(string code);
        CFG CreateControlFlowGraphForDisplay(string code);
        Metrics GetMetricsAsync(string code);
    }
}
