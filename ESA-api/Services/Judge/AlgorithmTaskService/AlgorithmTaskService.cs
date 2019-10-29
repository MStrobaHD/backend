using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;

namespace ESA_api.Services.Judge.AlgorithmTaskService
{
    public class AlgorithmTaskService : IAlgorithmTaskService
    {
        private readonly IAlgorithmTaskRepository _repository;
        private readonly IMapper _mapper;

        public AlgorithmTaskService(IAlgorithmTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AlgorithmTaskListForDisplayDTO> GetAlgorithmTaskForSolveAsync(int algorithmTaskId)
        {
            var task = await _repository.GetAlgorithmTasksForSolveAsync(algorithmTaskId);
            
            return _mapper.Map<AlgorithmTaskListForDisplayDTO>(task);
        }

        public async Task<List<AlgorithmTaskListForDisplayDTO>> GetAlgorithmTasksForDisplayAsync()
        {
            var tasks = await _repository.GetAlgorithmTasksForDisplayAsync();
            return _mapper.Map<List<AlgorithmTaskListForDisplayDTO>>(tasks);
        }
    }
}
