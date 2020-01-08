using ESA_api.Mapping.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.JudgeEngineService
{
    public interface IJudgeEngineService
    {
        Task<string> createSubmissionAsync(Submission submission);
        Task<string> createSubmissionWithInputAsync(SubmissionWithInput submission);
        Task<JsonCompilationResult> GetResultAsync(string solutionToken);
        Task<JsonAfterCompilationResult> GetFinalResultAsync(string solutionToken);
        Task<string> JudgeSolution(SubmissionWithInput submission);
        
    }
}
    