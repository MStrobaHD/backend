using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.VerificationDataRepository
{
    interface IVerificationDataRepository
    {
        Task<List<VerificationData>> GetVerificationDatasAsync();
        Task<VerificationData> GetVerificationDataAsync(int verificationDataId);
        Task AddVerificationDataAsync(VerificationData verificationData);
        Task UpdateVerificationDataAsync(VerificationData verificationData);
        Task DeleteVerificationDataAsync(int verificationDataId);
        Task<bool> FindVerificationDataAsync(int verificationDataId);
        Task<bool> VerificationDataExistsAsync(int verificationDataId);
        Task<VerificationData> GetVerificationDataFromDatabaseAsync(int verificationDataId);
    }
}
