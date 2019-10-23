using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.ComplexityRepository
{
    public interface IComplexityRepository
    {
        Task<List<Complexity>> GetComplexitysAsync();
        Task<Complexity> GetComplexityAsync(int complexityId);
        Task AddComplexityAsync(Complexity complexity);
        Task UpdateComplexityAsync(Complexity complexity);
        Task DeleteComplexityAsync(int complexityId);
        Task<bool> FindComplexityAsync(int complexityId);
        Task<bool> ComplexityExistsAsync(int complexityId);
        Task<Complexity> GetComplexityFromDatabaseAsync(int complexityId);
    }
}
