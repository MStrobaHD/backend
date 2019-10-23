using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.LevelRepository
{
    public interface ILevelRepository
    {
        Task<List<Level>> GetLevelsAsync();
        Task<Level> GetLevelAsync(int levelId);
        Task AddLevelAsync(Level level);
        Task UpdateLevelAsync(Level level);
        Task DeleteLevelAsync(int levelId);
        Task<bool> FindLevelAsync(int levelId);
        Task<bool> LevelExistsAsync(int levelId);
        Task<Level> GetLevelFromDatabaseAsync(int levelId);
    }
}
