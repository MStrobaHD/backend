using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.SolutionRepository
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly AppDatabaseContext _context;

        public SolutionRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddSolutionAsync(Solution solution)
        {
            _context.Solution.Add(solution);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSolutionAsync(int solutionId)
        {
            var solution = await _context.Solution.FindAsync(solutionId);
            _context.Solution.Remove(solution);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindSolutionAsync(int solutionId)
        {
            if (await _context.Solution.FindAsync(solutionId) != null)
                return true;
            return false;
        }

        public async Task<Solution> GetSolutionAsync(int solutionId)
        {
            return await _context.Solution
               .Where(solution => solution.Id == solutionId)
               .SingleOrDefaultAsync();
        }

        public async Task<Solution> GetSolutionFromDatabaseAsync(int solutionId)
        {
            return await _context.Solution.FindAsync(solutionId);
        }

        public async Task<List<Solution>> GetSolutionsAsync()
        {
            return await _context.Solution.ToListAsync();
        }

        public async Task<bool> SolutionExistsAsync(int solutionId)
        {
            return await _context.Solution.AnyAsync(x => x.Id == solutionId);
        }

        public async Task UpdateSolutionAsync(Solution solution)
        {
            _context.Entry(solution).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
