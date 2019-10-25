using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.ExternalService
{
    public class ExternalService : IExternalService
    {
        public ExternalService()
        {
        }

        public Task compileAndExecuteCodeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task createSubmissionAsync(int languageId)
        {
            HttpClient httpClient = new HttpClient();
            
           
            string createSubmissionRequest = "https://api.judge0.com/submissions/?base64_encoded=false&wait=false";


            HttpResponseMessage submissionResponse = await httpClient.GetAsync(createSubmissionRequest);
        }
    }
}
