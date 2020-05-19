using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.ExamResultService
{
    public interface IExamResultService
    {
        Task<BadgeDTO> AddExamResultAsync(ExamResultAddDTO examResultAddDTO);
        Task<List<ExamResultAddDTO>> GetExamResultsAsync(int userId);
    }
}
