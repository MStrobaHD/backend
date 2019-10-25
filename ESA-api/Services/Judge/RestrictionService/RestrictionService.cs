using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO;
using ESA_api.Models;
using ESA_api.Repositories.Judge.RestrictionRepository;

namespace ESA_api.Services.Judge.RestrictionService
{
    public class RestrictionService : IRestrictionService
    {
        private readonly IRestrictionRepository _repository;
        private readonly IMapper _mapper;

        public RestrictionService(IRestrictionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddRestrictionAsync(RestrictionAddDTO restrictionAddDTO)
        {
                var restriction = _mapper.Map<Restriction>(restrictionAddDTO);
                await _repository.AddRestrictionAsync(restriction);
                return restriction.Id;
            
        }
    }
}
