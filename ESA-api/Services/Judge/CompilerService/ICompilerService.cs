using ESA_api.Mapping.Custom;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.CompilerService
{
    interface ICompilerService
    {
        Task<Input> CompileAsync(Input input);
        Task<int> RunExeAsync();
        Task RunExeWithCheckingAsync();
        Task AddMarkersAsync();
        Task AnalyzeSourceCode();
    }
}
