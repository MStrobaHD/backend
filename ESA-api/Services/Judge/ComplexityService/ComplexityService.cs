using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.ComplexitysDTO;
using ESA_api.Repositories.Judge.ComplexityRepository;

namespace ESA_api.Services.Judge.ComplexityService
{
    public class ComplexityService : IComplexityService
    {
        private readonly IComplexityRepository _repository;
        private readonly IMapper _mapper;

        public ComplexityService(IComplexityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ComplexityListDTO>> GetComplexitiesAsync()
        {
            var complexities = await _repository.GetComplexitysAsync();
            return _mapper.Map<List<ComplexityListDTO>>(complexities);
        }
    }
}
