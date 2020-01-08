using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.ExamRepository
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetExamsAsync();
        Task<Exam> GetExamAsync(int examId);
        Task<List<Exam>> GetCourseExamsAsync(int courseId);
        // Task<List<Exam>> GetExamsByTypeAsync(int examTypeId);
        Task<Exam> GetMultiSelectQuestionsOfExam(int examId);
        Task<Exam> GetQuestionsOfExam(int examId);
        Task<Exam> GetOrderedBlocksOfExam(int examId);
        Task AddExamAsync(Exam exam);
        Task UpdateExamAsync(Exam exam);
        Task DeleteExamAsync(int examId);
        Task<bool> FindExamAsync(int examId);
        Task<bool> ExamExistsAsync(int examId);
        Task<Exam> GetExamFromDatabaseAsync(int examId);
    }
}
