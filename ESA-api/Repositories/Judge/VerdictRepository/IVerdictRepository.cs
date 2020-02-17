using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.VerdictRepository
{
    public interface IVerdictRepository
    {
        Task<List<Verdict>> GetUserVerdictsAsync(int userId);
        Task<Verdict> GetVerdictAsync(int verdictId);
        Task AddVerdictAsync(Verdict verdict);
        Task UpdateVerdictAsync(Verdict verdict);
        Task DeleteVerdictAsync(int verdictId);
        Task<bool> FindVerdictAsync(int verdictId);
        Task<bool> VerdictExistsAsync(int verdictId);
        Task<Verdict> GetVerdictFromDatabaseAsync(int verdictId);
    }
}
