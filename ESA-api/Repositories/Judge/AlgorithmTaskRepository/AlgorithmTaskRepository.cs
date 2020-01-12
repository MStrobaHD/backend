using ESA_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.AlgorithmTaskRepository
{
    public class AlgorithmTaskRepository : IAlgorithmTaskRepository
    {
        private readonly AppDatabaseContext _context;

        public AlgorithmTaskRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAlgorithmTaskAsync(AlgorithmTask algorithmTask)
        {
            _context.AlgorithmTask.Add(algorithmTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AlgorithmTaskExistsAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask.AnyAsync(x => x.Id == algorithmTaskId);
        }

        public async Task DeleteAlgorithmTaskAsync(int algorithmTaskId)
        {
            var algorithmTask = await _context.AlgorithmTask.FindAsync(algorithmTaskId);
            _context.AlgorithmTask.Remove(algorithmTask);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindAlgorithmTaskAsync(int algorithmTaskId)
        {
            if (await _context.AlgorithmTask.FindAsync(algorithmTaskId) != null)
                return true;
            return false;
        }

        public async Task<AlgorithmTask> GetAlgorithmTaskAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask
                .Where(algorithmTask => algorithmTask.Id == algorithmTaskId)
                .SingleOrDefaultAsync();
        }

        public async Task<AlgorithmTask> GetAlgorithmTaskFromDatabaseAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask.FindAsync(algorithmTaskId);
        }

        public async Task<List<AlgorithmTask>> GetAlgorithmTasksAsync()
        {
            return await _context.AlgorithmTask.ToListAsync();
        }

        public async Task<List<AlgorithmTask>> GetAlgorithmTasksForDisplayAsync()
        {
            return await _context.AlgorithmTask
                .Include(user => user.User)
                .Include(complexity => complexity.Complexity)
                .Include(algorithmCategory => algorithmCategory.AlgorithmCategory)
                .Include(level => level.Level).ToListAsync();
        }

        public async Task<AlgorithmTask> GetAlgorithmTasksForSolveAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask
                .Where(algorithmTask => algorithmTask.Id == algorithmTaskId)
                .Include(user => user.User)
                .Include(complexity => complexity.Complexity)
                .Include(algorithmCategory => algorithmCategory.AlgorithmCategory)
                .Include(level => level.Level)
                .Include(data => data.VerificationData).SingleOrDefaultAsync();
        }

        public async Task UpdateAlgorithmTaskAsync(AlgorithmTask algorithmTask)
        {
            _context.Entry(algorithmTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
