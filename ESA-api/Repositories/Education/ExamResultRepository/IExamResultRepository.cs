using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.ExamResultRepository
{
    public interface IExamResultRepository
    {
        Task AddResultAsync(ExamResult  examResult);
        Task<List<ExamResult>> GetExamResultsAsync(int userId);
    }
}
