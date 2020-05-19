using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly AppDatabaseContext _context;

        public StatisticsRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> CountAlgorithmsTaskAsync()
        {
            return await _context.AlgorithmTask
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<int> CountAvailableCoursesAsync()
        {
            return await _context.Course
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<int> CountExamsAsync()
        {
            return await _context.Exam
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<int> CountNegativeExamsAsync()
        {
            return await _context.ExamResult
                .AsNoTracking()
                .CountAsync();
        }

        public Task<int> CountPositiveExamsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountRegisteredTeachersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CountRegisteredUsersAsync()
        {
            return await _context.User
                .AsNoTracking()
                .CountAsync();
        }

        public Task<int> CountSolvedAlgorithmsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
