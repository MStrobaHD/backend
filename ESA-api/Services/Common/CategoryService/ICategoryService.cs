using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Common.CategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetCategoryAsync(int id);
        Task<int> AddCategoryAsync(CategoryAddDTO categoryAddDTO);
        Task<int> UpdateCategoryAsync(int categoryId, CategoryAddDTO categoryAddDTO);
        Task DeleteCategoryAsync(int categoryId);
        Task<bool> FindCategoryAsync(int categoryId);
        Task<bool> CategoryExistsAsync(int categoryId);
    }
}
