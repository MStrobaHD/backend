using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.ExamResultService
{
    public interface IExamResultService
    {
        Task<int> AddExamResultAsync(ExamResultAddDTO examResultAddDTO);
    }
}
