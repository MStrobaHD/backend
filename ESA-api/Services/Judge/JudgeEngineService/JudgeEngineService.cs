using AutoMapper;
using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Models;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;
using ESA_api.Repositories.Judge.VerdictRepository;
using ESA_api.Services.Judge.CodeAnalyzeService;
using ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels;
using ESA_api.Services.Judge.VerdictService;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Metrics = ESA_api.Models.Metrics;

namespace ESA_api.Services.Judge.JudgeEngineService
{
    public class JudgeEngineService : IJudgeEngineService
    {
        private readonly IAlgorithmTaskRepository _repository;
        private readonly IVerdictRepository _verdictRepository;
        private readonly IVerdictService _verdictService;
        private readonly IMapper _mapper;
        private readonly ICodeAnalyzeService _codeAnalyzeService;

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
        public JudgeEngineService(IAlgorithmTaskRepository repository, IVerdictRepository verdictRepository, IVerdictService verdictService, IMapper mapper, ICodeAnalyzeService codeAnalyzeService)
        {
            _repository = repository;
            _verdictRepository = verdictRepository;
            _verdictService = verdictService;
            _mapper = mapper;
            _codeAnalyzeService = codeAnalyzeService;
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

        public async Task<VerdictName> JudgeSolution(SubmissionWithInput submission)
        {
            int verdictId;
            bool isPlagiat;
            string submissionToken;
            Verdict verdict = new Verdict();
            VerdictName verdictName = new VerdictName();

            var task = await _repository.GetAlgorithmTasksForSolveAsync(submission.algorithmTaskId); 
            


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
                verdictName.Verdict = Verdicts.CompilationError.ToString();
                verdict.VerdictName = verdictName.Verdict;
                verdict.AlgorithmTaskName = submission.algorithmTaskName;
                verdict.Solution = submission.source_code;
                verdict.UserId = submission.userId;
                verdict.AlgorithmTaskId = task.Id;
                verdict.IsCopied = null;
                verdict.SimilarTaskId = null;
                await _verdictRepository.AddVerdictAsync(verdict);
            }
            else
            {
                JsonAfterCompilationResult submissionResult = await GetFinalResultAsync(submissionToken);
                string time = submissionResult.time.Replace(".", ",");
                submissionResult.time = time;

                verdictName.Verdict = Judge(submissionResult, task, submission);
                var copyResult = await AnalyzeSolutionCopyRatio(submission.source_code, submission.algorithmTaskId);

                if (copyResult.Count >= 1)
                {
                    isPlagiat = true;
                } else
                {
                    isPlagiat = false;
                }
                var metrics = _codeAnalyzeService.GetMetricsAsync(submission.source_code);

                // verdict.VerdictName = verdictName.Verdict;
                verdict.Solution = submission.source_code;
                verdict.AlgorithmTaskName = submission.algorithmTaskName;
                verdict.Time = Convert.ToDecimal(time);
                verdict.Memory = Convert.ToDecimal(submissionResult.memory);
                verdict.LinesOfCode = metrics.LinesOfCode;
                verdict.CyclomaticComplexity = metrics.CyclomaticComplexity;
                verdict.NumberOfDecision = metrics.NumberOfDecision;
                verdict.NumberOfAssignment = metrics.NumberOfAssignment;
                verdict.UserId = submission.userId;
                verdict.AlgorithmTaskId = task.Id;

                // nadanie werdyktu plagiat
                if (isPlagiat == true)
                {
                    verdict.IsCopied = 1;
                    verdict.VerdictName = "Plagiat";
                    var mappedVerdict = _mapper.Map<VerdictAddDTO>(verdict);
                    verdictId = await _verdictService.AddVerdictAsync(mappedVerdict);
                } else
                {
                    verdict.IsCopied = 0;
                    verdict.VerdictName = verdictName.Verdict;
                    var mappedVerdict = _mapper.Map<VerdictAddDTO>(verdict);
                    verdictId = await _verdictService.AddVerdictAsync(mappedVerdict);
                }
                // dodanie informacji o pracach które są podobne do tej pracy
                foreach (var copy in copyResult)
                {
                    copy.VerdictId = verdictId;
                   
                    var mappedCopy = _mapper.Map<CopiedSolution>(copy);
                    await _verdictRepository.AddCopySolutionAsync(mappedCopy);
                }

               // if (verdictName.Verdict == "Accepted" || verdictName.Verdict == "Plagiat")
               // {
                    var mappedMetrics = _mapper.Map<Metrics>(metrics);
                    mappedMetrics.VerdictId = verdictId;
                    await _verdictRepository.AddMetricsAsync(mappedMetrics);
               // }
            }
            verdictName.Verdict = verdict.VerdictName;
            return verdictName;
        }

        private string Judge(JsonAfterCompilationResult submissionResult, AlgorithmTask task, SubmissionWithInput submission)
        {
            string verdict = "";
            string stdout;
            stdout = submissionResult.stdout.Replace("\n", "");
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

                else if (Convert.ToDecimal(submissionResult.time) > task.TimeLimit)
                {
                    verdict = Verdicts.TimeLimitExceeded.ToString();
                }
                else if (submissionResult.memory > task.MemoryLimit)
                {
                    verdict = Verdicts.MemoryLimitExceeded.ToString();
                }
                else if (submission.stdin == data.InputData && stdout == data.OutputData)
                {
                    verdict = Verdicts.Accepted.ToString();
                    var metrics = _codeAnalyzeService.GetMetricsAsync(submission.source_code);

                }
                else if (submission.stdin == data.InputData && stdout != data.OutputData)
                {
                    verdict = Verdicts.NotAccepted.ToString();
                }
                else if (stdout != data.OutputData)
                {
                    verdict = Verdicts.NotAccepted.ToString();
                }
                else if (stdout == data.OutputData)
                {
                    verdict = Verdicts.Accepted.ToString();
                }
            }
            return verdict;
        }
        private async Task<List<CopiedSolutionDTO>> AnalyzeSolutionCopyRatio(string submittedSourceCode, int taskId)
        {
            CopiedSolutionDTO copiedSolution = new CopiedSolutionDTO();
            List<CopiedSolutionDTO> copiedSolutionList = new List<CopiedSolutionDTO>();

            int uniqueOperators;
            int uniqueOperands;
            int numberOfOperators;
            int numberOfOperands;

            int averageUniqueOperators;
            int averageUniqueOperands;
            int averageNumberOfOperators;
            int averageNumberOfOperands;

            double COPY_RATIO = 0.1;

            double uniqueOperatorsSimilarity;
            double uniqueOperandsSimilarity;
            double numberOfOperatorsSimilarity;
            double numberOfOperandsSimilarity;

            var existingSolutions = await _verdictRepository.GetVerdictWithMetricsByTaskId(taskId);
            var actualTaskMetrics = _codeAnalyzeService.GetMetricsAsync(submittedSourceCode);

            foreach (var solution in existingSolutions)
            {
                foreach (var metric in solution.Metrics)
                {
                    if (solution.VerdictName == "Accepted")
                    {
                        averageUniqueOperators = (metric.NumberOfUniqueOperators + actualTaskMetrics.NumberOfUniqueOperators) / 2;
                        averageUniqueOperands = (metric.NumberOfUniqueOperands + actualTaskMetrics.NumberOfUniqueOperands) / 2;
                        averageNumberOfOperators = (metric.NumberOfOperators + actualTaskMetrics.NumberOfOperators) / 2;
                        averageNumberOfOperands = (metric.NumberOfOperands + actualTaskMetrics.NumberOfOperands) / 2;

                        uniqueOperators = Math.Abs(metric.NumberOfUniqueOperators - actualTaskMetrics.NumberOfUniqueOperators);
                        uniqueOperands = Math.Abs(metric.NumberOfUniqueOperands - actualTaskMetrics.NumberOfUniqueOperands);
                        numberOfOperators = Math.Abs(metric.NumberOfOperators - actualTaskMetrics.NumberOfOperators);
                        numberOfOperands = Math.Abs(metric.NumberOfOperands - actualTaskMetrics.NumberOfOperands);

                        uniqueOperatorsSimilarity = (double)uniqueOperators / averageUniqueOperators;
                        uniqueOperandsSimilarity = (double)uniqueOperands / averageUniqueOperands;
                        numberOfOperatorsSimilarity = (double)numberOfOperators / numberOfOperators;
                        numberOfOperandsSimilarity = (double)numberOfOperands / averageNumberOfOperands;

                        if (uniqueOperatorsSimilarity > COPY_RATIO || uniqueOperandsSimilarity > COPY_RATIO || numberOfOperatorsSimilarity > COPY_RATIO || numberOfOperandsSimilarity > COPY_RATIO)
                        {
                            copiedSolution.AlgorithmTaskId = solution.AlgorithmTaskId;
                            copiedSolution.SimilarVerdictId = solution.Id;

                            copiedSolutionList.Add(copiedSolution);
                            copiedSolution = new CopiedSolutionDTO();
                        }
                       // else
                       // {
                            //copiedSolution.AlgorithmTaskId = solution.AlgorithmTaskId;
                            //copiedSolution.SimilarVerdictId = solution.Id;
                        //}
                        //copiedSolutionList.Add(copiedSolution);
                        //copiedSolution = new CopiedSolutionDTO();
                    }
                }
            }
            return copiedSolutionList;
        }
        int GetPercentageOfSimilarityLevel(WordSet wordSet, string sourceCode)
        {

            return 1;
        }
        public async Task<List<VerdictDTO>> GetCopiedSolutionAsync(int verdictId)
        {
            List<VerdictDTO> solutionList = new List<VerdictDTO>();

            var copyList = await _verdictRepository.GetCopiedSolutionListAsync(verdictId);
            foreach (var copy in copyList)
            {
                var verdict = await _verdictRepository.GetVerdictAsync((int)copy.SimilarVerdictId);
                var mappedVerdict = _mapper.Map<VerdictDTO>(verdict);
                solutionList.Add(mappedVerdict);
            }
            return solutionList;
        }
    }
}
