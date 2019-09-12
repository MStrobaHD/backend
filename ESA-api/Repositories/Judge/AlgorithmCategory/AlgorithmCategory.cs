
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.AlgorithmCategory
{
    public class AlgorithmCategory : IAlgorithmCategory
    {
        private readonly AppDatabaseContext _context;

        public AlgorithmCategory(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAlgorithmCategoryASync(AlgorithmCategory algorithmCategory)
        {
            _context.AlgorithmCategory.Add(algorithmCategory);
            await _context.SaveChangesAsync();
        }

        public Task AddAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AlgorithmCategoryExists(int algorithmCategoryId)
        {
            return await _context.AlgorithmCategory.AnyAsync(x => x.Id == algorithmCategoryId);
        }

        public Task DeleteAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FindAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AlgorithmCategory>> GetAlgorithmCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlgorithmCategory> GetAlgorithmCategoryAsync(int algorithmCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<AlgorithmCategory> GetAlgorithmCategoryFromDatabaseAsync(int algorithmCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory)
        {
            throw new NotImplementedException();
        }
    }
}
