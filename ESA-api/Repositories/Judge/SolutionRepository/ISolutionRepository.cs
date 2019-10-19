using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.SolutionRepository
{
    interface ISolutionRepository
    {
        Task<List<Solution>> GetSolutionsAsync();
        Task<Solution> GetSolutionAsync(int solutionId);
        Task AddSolutionAsync(Solution solution);
        Task UpdateSolutionAsync(Solution solution);
        Task DeleteSolutionAsync(int solutionId);
        Task<bool> FindSolutionAsync(int solutionId);
        Task<bool> SolutionExistsAsync(int solutionId);
        Task<Solution> GetSolutionFromDatabaseAsync(int solutionId);
    }
}
