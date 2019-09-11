using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.ExamRepository
{
    interface IExamRepository
    {
        Task<List<Exam>> GetExamsAsync();
        Task<Exam> GetExamAsync(int examId);
        Task<List<Exam>> GetCourseExamsAsync(int courseId);
        Task<List<Exam>> GetExamsByTypeAsync(int examTypeId);
        Task AddExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(int examId);
        Task<bool> FindExamAsync(int examId);
        Task<bool> ExamExistsAsync(int examId);
        Task<Exam> GetExamFromDatabaseAsync(int examId);
    }
}
