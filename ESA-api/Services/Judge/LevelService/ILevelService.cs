using ESA_api.Mapping.DTO.JudgeDTO.LevelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.LevelService
{
    public interface ILevelService
    {
        Task<List<LevelListDTO>> GetLevelsAsync();
    }
}
