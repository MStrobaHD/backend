using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.ComplexityRepository
{
    public class ComplexityRepository : IComplexityRepository
    {
        private readonly AppDatabaseContext _context;

        public ComplexityRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddComplexityAsync(Complexity complexity)
        {
            _context.Complexity.Add(complexity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ComplexityExistsAsync(int complexityId)
        {
            return await _context.Complexity.AnyAsync(x => x.Id == complexityId);
        }

        public async Task DeleteComplexityAsync(int complexityId)
        {
            var complexity = await _context.Complexity.FindAsync(complexityId);
            _context.Complexity.Remove(complexity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindComplexityAsync(int complexityId)
        {
            if (await _context.Complexity.FindAsync(complexityId) != null)
                return true;
            return false;
        }

        public async Task<Complexity> GetComplexityAsync(int complexityId)
        {
            return await _context.Complexity
               .Where(complexity => complexity.Id == complexityId)
               .AsNoTracking()
               .SingleOrDefaultAsync();
        }

        public async Task<Complexity> GetComplexityFromDatabaseAsync(int complexityId)
        {
            return await _context.Complexity.FindAsync(complexityId);
        }

        public async Task<List<Complexity>> GetComplexitysAsync()
        {
            return await _context.Complexity
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateComplexityAsync(Complexity complexity)
        {
            _context.Entry(complexity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
