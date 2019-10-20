using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Judge.RestrictionRepository
{
    public class RestrictionRepository : IRestrictionRepository
    {
        private readonly AppDatabaseContext _context;

        public RestrictionRepository(AppDatabaseContext context)
        {
           _context = context;
        }

        public async Task AddRestrictionAsync(Restriction restriction)
        {
            _context.Restriction.Add(restriction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRestrictionAsync(int restrictionId)
        {
            var restriction = await _context.Restriction.FindAsync(restrictionId);
            _context.Restriction.Remove(restriction);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindRestrictionAsync(int restrictionId)
        {
            if (await _context.Restriction.FindAsync(restrictionId) != null)
                return true;
            return false;
        }

        public async Task<Restriction> GetRestrictionAsync(int restrictionId)
        {
            return await _context.Restriction
                .Where(restriction => restriction.Id == restrictionId)
                .SingleOrDefaultAsync();
        }

        public async Task<Restriction> GetRestrictionFromDatabaseAsync(int restrictionId)
        {
            return await _context.Restriction.FindAsync(restrictionId);
        }

        public async Task<List<Restriction>> GetRestrictionsAsync()
        {
            return await _context.Restriction.ToListAsync();
        }

        public async Task<bool> RestrictionExistsAsync(int restrictionId)
        {
            return await _context.Restriction.AnyAsync(x => x.Id == restrictionId);
        }

        public async Task UpdateRestrictionAsync(Restriction restriction)
        {
            _context.Entry(restriction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
