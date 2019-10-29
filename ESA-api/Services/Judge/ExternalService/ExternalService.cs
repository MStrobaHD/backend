using ESA_api.Mapping.Custom;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.ExternalService
{
    public class ExternalService : IExternalService
    {
        public ExternalService()
        {
        }

       
  
        public  async Task<string> createSubmissionAsync(Submission httpBody)
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

        public async Task<string> GetFinalResultAsync(string solutionToken)
        {
            string URI = String.Format("https://api.judge0.com/submissions/{0}?base64_encoded=false", solutionToken);
            HttpClient httpClient = new HttpClient();

            // Thread.Sleep(2000);

            HttpResponseMessage submissionResponse = await httpClient.GetAsync(URI).ConfigureAwait(false);
            var result = await submissionResponse.Content.ReadAsStringAsync();

            return result;
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

        public async Task<Submission> PrepareSubmission(Submission submission)
        {
            submission.source_code = submission.source_code.Replace('"', '\"');

            return submission;
        }

        public Submission ReplaceAsync(Submission submission)
        {
            submission.source_code = submission.source_code.Replace('"', '\"');
            return   submission;
        }
    }
}
