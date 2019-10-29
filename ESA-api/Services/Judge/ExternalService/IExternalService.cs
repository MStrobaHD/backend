using ESA_api.Mapping.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.ExternalService
{
    public interface IExternalService
    {
        Task<string> createSubmissionAsync(Submission submission);
        Task<JsonCompilationResult> GetResultAsync(string solutionToken);
        Task<string> GetFinalResultAsync(string solutionToken);
        //Task<JsonCompilationResult> GetFinalResult(Submission submission);
        Submission ReplaceAsync(Submission submission);
        Task<Submission> PrepareSubmission(Submission submission);
    }
}
