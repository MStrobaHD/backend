using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.VerdictService
{
    public interface IVerdictService
    {
        Task<int> AddVerdictAsync(VerdictAddDTO verdictAddDTO);
    }
}
