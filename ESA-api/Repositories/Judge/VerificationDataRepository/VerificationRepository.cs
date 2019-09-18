using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.VerificationDataRepository
{
    public class VerificationRepository : IVerificationDataRepository
    {
        private readonly AppDatabaseContext _context;

        public VerificationRepository(AppDatabaseContext context)
        {
           _context = context;
        }

        public async Task AddVerificationDataAsync(VerificationData verificationData)
        {
            _context.VerificationData.Add(verificationData);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVerificationDataAsync(int verificationDataId)
        {
            var verificationData = await _context.VerificationData.FindAsync(verificationDataId);
            _context.VerificationData.Remove(verificationData);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindVerificationDataAsync(int verificationDataId)
        {
            if (await _context.VerificationData.FindAsync(verificationDataId) != null)
                return true;
            return false;
        }

        public async Task<VerificationData> GetVerificationDataAsync(int verificationDataId)
        {
            return await _context.VerificationData
                .Where(verificationData => verificationData.Id == verificationDataId)
                .SingleOrDefaultAsync();
        }

        public async Task<VerificationData> GetVerificationDataFromDatabaseAsync(int verificationDataId)
        {
            return await _context.VerificationData.FindAsync(verificationDataId);
        }

        public async Task<List<VerificationData>> GetVerificationDatasAsync()
        {
            return await _context.VerificationData.ToListAsync();
        }

        public async Task UpdateVerificationDataAsync(VerificationData verificationData)
        {
            _context.Entry(verificationData).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerificationDataExistsAsync(int verificationDataId)
        {
            return await _context.VerificationData.AnyAsync(x => x.Id == verificationDataId);
        }
    }
}
