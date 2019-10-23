using ESA_api.Mapping.DTO.JudgeDTO.ComplexitysDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.ComplexityService
{
    public interface IComplexityService
    {
        Task<List<ComplexityListDTO>> GetComplexitiesAsync();
    }
}
