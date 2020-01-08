using ESA_api.Mapping.Custom;
using ESA_api.Model;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.JudgeEngineService
{
    public class JudgeEngineService : IJudgeEngineService
    {
        private readonly IAlgorithmTaskRepository _repository;
        enum Verdicts
        {
            Accepted = 0,
            NotAccepted = 1,
            CompilationError = 2,
            RuntimeError = 3,
            MemoryLimitExceeded = 4,
            TimeLimitExceeded = 5,
            LinesOfCodeLimitExceeded = 6

        }
        public JudgeEngineService(IAlgorithmTaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> createSubmissionAsync(Submission httpBody)
        {
            httpBody.source_code = httpBody.source_code.Replace('"', '\"');

            string URI = "https://api.judge0.com/submissions/?base64_encoded=false&wait=false";
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage submissionResponse = await httpClient.PostAsJsonAsync(URI, httpBody);
            var content = submissionResponse.Content.ReadAsStringAsync();

            JsonSerializer serializer = new JsonSerializer();
            SolutionResult solutionResult = serializer.Deserialize<SolutionResult>(new JsonTextReader(new StringReader(content.Result)));

            string token = solutionResult.token;

            return token;
        }

        public async Task<string> createSubmissionWithInputAsync(SubmissionWithInput httpBody)
        {
            httpBody.source_code = httpBody.source_code.Replace('"', '\"');

            string URI = "https://api.judge0.com/submissions/?base64_encoded=false&wait=false";
            HttpClient httpClient = new HttpClient();


            HttpResponseMessage submissionResponse = await httpClient.PostAsJsonAsync(URI, httpBody);
            var content = submissionResponse.Content.ReadAsStringAsync();

            JsonSerializer serializer = new JsonSerializer();
            SolutionResult solutionResult = serializer.Deserialize<SolutionResult>(new JsonTextReader(new StringReader(content.Result)));

            string token = solutionResult.token;

            return token;
        }

        //public Task<int> GetElementaryOperationNumber(Submission submission)
        //{
        //    //var codeWithAddedMarker = submission;
        //    StringBuilder codeWithAddedMarker = new StringBuilder();

        //    string[] sourceCode = submission.source_code.Split(new string[] { "\n" }, StringSplitOptions.None);
        //    foreach (var line in sourceCode)
        //    {
        //        // znajdz maina i dodaj int operatorCounter = 0;
        //        // 
        //    }
        //    return 0;
        //}

        public async Task<JsonAfterCompilationResult> GetFinalResultAsync(string solutionToken)
        {
            string URI = String.Format("https://api.judge0.com/submissions/{0}?base64_encoded=false", solutionToken);
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage submissionResponse = await httpClient.GetAsync(URI).ConfigureAwait(false);
            var result = await submissionResponse.Content.ReadAsStringAsync();

            var serializer = new JavaScriptSerializer();
            JsonAfterCompilationResult compilationResult = serializer.Deserialize<JsonAfterCompilationResult>(result);

            return compilationResult;
        }

        public async Task<JsonCompilationResult> GetResultAsync(string token)
        {

            string URI = String.Format("https://api.judge0.com/submissions/{0}?base64_encoded=false", token);
            HttpClient httpClient = new HttpClient();

            // Thread.Sleep(2000);

            HttpResponseMessage submissionResponse = await httpClient.GetAsync(URI).ConfigureAwait(false);
            var result = await submissionResponse.Content.ReadAsStringAsync();

            var serializer = new JavaScriptSerializer();
            JsonCompilationResult compilationResult = serializer.Deserialize<JsonCompilationResult>(result);

            return compilationResult;

        }

        public async Task<string> JudgeSolution(SubmissionWithInput submission)
        {
            string verdict;
            string submissionToken;
            var task = await _repository.GetAlgorithmTasksForSolveAsync(1); // return specific task with parameters

            
            if (submission.stdin != "")
            {
                submissionToken = await createSubmissionWithInputAsync(submission);
            }
            else
            {
                Submission submissionWithNoInput = new Submission();
                submissionWithNoInput.language_id = submission.language_id;
                submissionWithNoInput.source_code = submission.source_code;
                submissionToken = await createSubmissionAsync(submissionWithNoInput);
            }
            
            JsonCompilationResult result;
            result = await GetResultAsync(submissionToken);

            while (result.stdout == null && result.compile_output == null)
            {
                result = await GetResultAsync(submissionToken);
            }
            if (result.compile_output != null)
            {
                verdict = Verdicts.CompilationError.ToString();
            } else
            {
                JsonAfterCompilationResult submissionResult = await GetFinalResultAsync(submissionToken);
                verdict = Judge(submissionResult, task, submission);
            }

            return verdict;
        }

        private string Judge(JsonAfterCompilationResult submissionResult, AlgorithmTask task, SubmissionWithInput submission)
        {
            string verdict = "";
            foreach (var data in task.VerificationData)
            {
                if (submissionResult.stderr != null)
                {
                    verdict = Verdicts.CompilationError.ToString();
                }
                if (submissionResult.stderr != null)
                {
                    verdict = Verdicts.RuntimeError.ToString();
                }
                else if (submission.stdin == data.InputData &&  submissionResult.stdout == data.OutputData)
                {
                    verdict = Verdicts.Accepted.ToString();
                } 
                else if (submission.stdin == data.InputData && submissionResult.stdout != data.OutputData)
                {
                    verdict = Verdicts.NotAccepted.ToString();
                }
                else if (int.Parse(submissionResult.time) > task.TimeLimit)
                {
                    verdict = Verdicts.TimeLimitExceeded.ToString();
                }
                else if (submissionResult.memory > task.MemoryLimit)
                {
                    verdict = Verdicts.MemoryLimitExceeded.ToString();
                }

            }
            return verdict;
        }
    }
}
