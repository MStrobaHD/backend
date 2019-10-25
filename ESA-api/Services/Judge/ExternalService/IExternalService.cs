using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.ExternalService
{
    public interface IExternalService
    {
        Task createSubmissionAsync(int languageId);
        Task compileAndExecuteCodeAsync();
    }
}
