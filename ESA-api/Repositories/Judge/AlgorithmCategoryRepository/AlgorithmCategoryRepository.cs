using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.AlgorithmCategoryRepository
{
    public class AlgorithmCategoryRepository : IAlgorithmCategoryRepository
    {
        private readonly AppDatabaseContext _context;

        public AlgorithmCategoryRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory)
        {
            _context.AlgorithmCategory.Add(algorithmCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AlgorithmCategoryExistsAsync(int algorithmCategoryId)
        {
            return await _context.AlgorithmCategory.AnyAsync(x => x.Id == algorithmCategoryId);
        }

        public async Task DeleteAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            var algorithmCategory = await _context.AlgorithmCategory.FindAsync(algorithmCategoryId);
            _context.AlgorithmCategory.Remove(algorithmCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            if (await _context.AlgorithmTask.FindAsync(algorithmCategoryId) != null)
                return true;
            return false;
        }

        public async Task<List<AlgorithmCategory>> GetAlgorithmCategoriesAsync()
        {
            return await _context.AlgorithmCategory.ToListAsync();
        }

        public async Task<AlgorithmCategory> GetAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            return await _context.AlgorithmCategory
                .Where(algorithmCategory => algorithmCategory.Id == algorithmCategoryId)
                .SingleOrDefaultAsync();
        }

        public async Task<AlgorithmCategory> GetAlgorithmCategoryFromDatabaseAsync(int algorithmCategoryId)
        {
            return await _context.AlgorithmCategory.FindAsync(algorithmCategoryId);
        }

        public async Task UpdateAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory)
        {
            _context.Entry(algorithmCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
