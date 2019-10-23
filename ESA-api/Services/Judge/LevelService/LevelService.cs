using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.LevelsDTO;
using ESA_api.Repositories.Judge.LevelRepository;

namespace ESA_api.Services.Judge.LevelService
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _repository;
        private readonly IMapper _mapper;

        public LevelService(ILevelRepository repository, 
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LevelListDTO>> GetLevelsAsync()
        {
            var levels = await _repository.GetLevelsAsync();
            return _mapper.Map<List<LevelListDTO>>(levels);
        }
    }
}
