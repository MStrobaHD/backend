using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;

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
    }
}
