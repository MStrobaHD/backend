using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.VerificationDataService
{
    public interface IVerificationDataService
    {
        Task<int> AddVerificationDataAsync(VerificationDataAddDTO verificationDataAddDTO);
    }
}
