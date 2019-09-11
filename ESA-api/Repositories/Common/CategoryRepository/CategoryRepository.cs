using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDatabaseContext _context;

        public CategoryRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Category.AnyAsync(x => x.Id == categoryId);
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Course.FindAsync(categoryId);
            _context.Course.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindCategoryAsync(int categoryId)
        {
            if (await _context.Category.FindAsync(categoryId) != null)
                return true;
            return false;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Category.Where(category => category.Id == categoryId).SingleOrDefaultAsync();
        }

        public async Task<Category> GetCategoryFromDatabaseAsync(int categoryId)
        {
            return await _context.Category.Where(category => category.Id == categoryId).SingleOrDefaultAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
