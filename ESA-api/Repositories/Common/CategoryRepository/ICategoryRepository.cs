using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(int categoryId);
        Task<List<Category>> GetCategoriesAsync();
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> FindCategoryAsync(int categoryId);
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<Category> GetCategoryFromDatabaseAsync(int categoryId);
    }
}
