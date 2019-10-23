using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmCategorysDTO;
using ESA_api.Repositories.Judge.AlgorithmCategoryRepository;

namespace ESA_api.Services.Judge.AlgorithmCategoryService
{
    public class AlgorithmCategoryService : IAlgorithmCategoryService
    {
        private readonly IAlgorithmCategoryRepository _repository;
        private readonly IMapper _mapper;

        public AlgorithmCategoryService(IAlgorithmCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<AlgorithmCategoryListDTO>> GetCategoriesAsync()
        {
            var categories = await _repository.GetAlgorithmCategoriesAsync();
            return _mapper.Map<List<AlgorithmCategoryListDTO>>(categories);
        }
    }
}
