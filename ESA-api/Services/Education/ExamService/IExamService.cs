using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.ExamService
{
   public interface IExamService
    {
        Task<List<ExamListDTO>> GetExamsAsync();
        Task<ExamDTO> GetExamAsync(int id);
        Task<List<ExamListDTO>> GetCourseExamsAsync(int courseId);
        Task<List<ExamListDTO>> GetAvailableExamsAsync(int courseId, int userId);
        Task<int> AddExamAsync(ExamAddDTO examAddDTO);
        Task<int> UpdateExamAsync(int examId, ExamAddDTO examAddDTO);
        Task DeleteExamAsync(int examId);
        Task<bool> FindExamAsync(int examId);
    }
}
