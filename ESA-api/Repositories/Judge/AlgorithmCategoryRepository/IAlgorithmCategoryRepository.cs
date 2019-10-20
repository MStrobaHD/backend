using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.AlgorithmCategoryRepository
{
    interface IAlgorithmCategoryRepository
    {
        Task<List<AlgorithmCategory>> GetAlgorithmCategoriesAsync();
        Task<AlgorithmCategory> GetAlgorithmCategoryAsync(int algorithmCategoryId);
        Task AddAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory);
        Task UpdateAlgorithmCategoryAsync(AlgorithmCategory algorithmCategory);
        Task DeleteAlgorithmCategoryAsync(int algorithmCategoryId);
        Task<bool> FindAlgorithmCategoryAsync(int algorithmCategoryId);
        Task<bool> AlgorithmCategoryExistsAsync(int algorithmCategoryId);
        Task<AlgorithmCategory> GetAlgorithmCategoryFromDatabaseAsync(int algorithmCategoryId);
    }
}
