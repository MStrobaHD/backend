using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.VerdictRepository
{
    public class VerdictRepository : IVerdictRepository
    {
        private readonly AppDatabaseContext _context;

        public VerdictRepository(AppDatabaseContext context)
        {
           _context = context;
        }

        public async Task AddVerdictAsync(Verdict verdict)
        {
            _context.Verdict.Add(verdict);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVerdictAsync(int verdictId)
        {
            var verdict = await _context.Verdict.FindAsync(verdictId);
            _context.Verdict.Remove(verdict);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindVerdictAsync(int verdictId)
        {
            if (await _context.Verdict.FindAsync(verdictId) != null)
                return true;
            return false;
        }

        public async Task<Verdict> GetVerdictAsync(int verdictId)
        {
            return await _context.Verdict
               .Where(verdict => verdict.Id == verdictId)
               .SingleOrDefaultAsync();
        }

        public async Task<Verdict> GetVerdictFromDatabaseAsync(int verdictId)
        {
            return await _context.Verdict.FindAsync(verdictId);
        }

        public async Task<List<Verdict>> GetUserVerdictsAsync(int userId)
        {
            return await _context.Verdict.Where(verdict => verdict.UserId == userId).ToListAsync();
        }

        public async Task UpdateVerdictAsync(Verdict verdict)
        {
            _context.Entry(verdict).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerdictExistsAsync(int verdictId)
        {
            return await _context.Verdict.AnyAsync(x => x.Id == verdictId);
        }
    }
}
