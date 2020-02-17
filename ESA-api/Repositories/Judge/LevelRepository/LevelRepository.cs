using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.LevelRepository
{
    public class LevelRepository : ILevelRepository
    {
        private readonly AppDatabaseContext _context;

        public LevelRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddLevelAsync(Level level)
        {
            _context.Level.Add(level);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLevelAsync(int levelId)
        {
            var level = await _context.Level.FindAsync(levelId);
            _context.Level.Remove(level);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindLevelAsync(int levelId)
        {
            if (await _context.Level.FindAsync(levelId) != null)
                return true;
            return false;
        }

        public async Task<Level> GetLevelAsync(int levelId)
        {
            return await _context.Level
                .Where(level => level.Id == levelId)
                .SingleOrDefaultAsync();
        }

        public async Task<Level> GetLevelFromDatabaseAsync(int levelId)
        {
            return await _context.Level.FindAsync(levelId);
        }

        public async Task<List<Level>> GetLevelsAsync()
        {
            return await _context.Level.ToListAsync();
        }

        public async Task<bool> LevelExistsAsync(int levelId)
        {
            return await _context.Level.AnyAsync(x => x.Id == levelId);
        }

        public async Task UpdateLevelAsync(Level level)
        {
            _context.Entry(level).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
