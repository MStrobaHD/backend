using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using ESA_api.Model;
using ESA_api.Repositories.Common.CategoryRepository;

namespace ESA_api.Services.Common.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryAddDTO categoryAddDTO)
        {
            var category = _mapper.Map<Category>(categoryAddDTO);
            await _repository.AddCategoryAsync(category);
            return category.Id;
        }

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            await _repository.DeleteCategoryAsync(categoryId);
        }

        public async Task<bool> FindCategoryAsync(int categoryId)
        {
            if (await _repository.FindCategoryAsync(categoryId))
                return true;
            return false;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()   
        {
            var category = await _repository.GetCategoriesAsync();
            return _mapper.Map<List<CategoryDTO>>(category);
        }

        public async Task<CategoryDTO> GetCategoryAsync(int id)
        {
            var category = await _repository.GetCategoryAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<int> UpdateCategoryAsync(int categoryId, CategoryAddDTO categoryAddDTO)
        {
            var categoryFromDatabase = await _repository.GetCategoryFromDatabaseAsync(categoryId);
            var categoryToDatabase = _mapper.Map(categoryAddDTO, categoryFromDatabase);

            await _repository.UpdateCategoryAsync(categoryToDatabase);
            return categoryToDatabase.Id;
        }
    }
}
