using ESA_api.Models;
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
                .Include(level => level.Level)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AlgorithmTask> GetAlgorithmTasksForSolveAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask
                .Where(algorithmTask => algorithmTask.Id == algorithmTaskId)
                .Include(user => user.User)
                .Include(complexity => complexity.Complexity)
                .Include(algorithmCategory => algorithmCategory.AlgorithmCategory)
                .Include(level => level.Level)
                .Include(data => data.VerificationData)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<Rating> GetActualRatingAsync(int algorithmTaskId, int userId)
        {
            return await _context.Rating.Where(exp => exp.AlgorithmTaskId == algorithmTaskId && exp.UserId == userId).SingleOrDefaultAsync();
        }   

        public async Task<List<Rating>> GetRateListByIdAsync(int id)
        {
            return await _context.Rating.Where(rate => rate.AlgorithmTaskId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> isRatedAlready(int? algorithmTaskId, int? userId)
        {
            var rating = await _context.Rating.Where(exp => exp.AlgorithmTaskId == algorithmTaskId && exp.UserId == userId).SingleOrDefaultAsync();

            if (rating != null)
                return true;
            return false;
        }

        public async Task RateAsync(Rating rating)
        {
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAlgorithmTaskAsync(AlgorithmTask algorithmTask)
        {
            _context.Entry(algorithmTask).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(Rating task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
