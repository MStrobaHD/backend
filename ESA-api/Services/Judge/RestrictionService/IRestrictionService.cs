using ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.RestrictionService
{
    public interface IRestrictionService
    {
        Task<int> AddRestrictionAsync(RestrictionAddDTO restrictionAddDTO);
    }
}
