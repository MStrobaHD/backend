using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.AlgorithmTaskService
{
    public interface IAlgorithmTaskService
    {
        Task<List<AlgorithmTaskListForDisplayDTO>> GetAlgorithmTasksForDisplayAsync();
        Task<AlgorithmTaskListForDisplayDTO> GetAlgorithmTaskForSolveAsync(int algorithmTaskId);
    }
}
