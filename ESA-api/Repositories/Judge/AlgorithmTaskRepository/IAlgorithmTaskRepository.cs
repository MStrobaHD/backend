using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.AlgorithmTaskRepository
{
    public interface IAlgorithmTaskRepository
    {
        Task<List<AlgorithmTask>> GetAlgorithmTasksAsync();
        Task<List<AlgorithmTask>> GetAlgorithmTasksForDisplayAsync();
        Task <AlgorithmTask> GetAlgorithmTasksForSolveAsync(int algorithmTaskId);
        Task<AlgorithmTask> GetAlgorithmTaskAsync(int algorithmTaskId);
        Task AddAlgorithmTaskAsync(AlgorithmTask algorithmTask);
        Task UpdateAlgorithmTaskAsync(AlgorithmTask algorithmTask);
        Task DeleteAlgorithmTaskAsync(int algorithmTaskId);
        Task<bool> FindAlgorithmTaskAsync(int algorithmTaskId);
        Task<bool> AlgorithmTaskExistsAsync(int algorithmTaskId);
        Task<AlgorithmTask> GetAlgorithmTaskFromDatabaseAsync(int algorithmTaskId);
    }
}
