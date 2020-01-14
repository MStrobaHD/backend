using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.AlgorithmTaskService
{
    public interface IAlgorithmTaskService
    {
        Task<List<AlgorithmTaskListForDisplayDTO>> GetAlgorithmTasksForDisplayAsync();
        Task<AlgorithmTaskForSolveDTO> GetAlgorithmTaskForSolveAsync(int algorithmTaskId);
        Task<int> AddAlgorithmTaskDTO(AlgorithmTaskAddDTO algorithmTaskAddDTO);
        Task<int> RateAsync(RatingDTO ratingDTO);
    }
}
