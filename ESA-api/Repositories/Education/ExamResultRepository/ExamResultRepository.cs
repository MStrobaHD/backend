using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Model;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Education.ExamResultRepository
{
    public class ExamResultRepository: IExamResultRepository
    {
        private readonly AppDatabaseContext _context;

        public ExamResultRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddResultAsync(ExamResult examResult)
        {
            _context.ExamResult.Add(examResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ExamResult>> GetExamResultsAsync(int userId)
        {
            return await _context.ExamResult.Where(exam => exam.UserId == userId).ToListAsync();
        }
    }
}
