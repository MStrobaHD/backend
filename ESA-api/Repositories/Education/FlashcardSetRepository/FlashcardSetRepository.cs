using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.FlashcardSerRepository
{
    public class FlashcardSetRepository : IFlashcardSetRepository
    {
        private readonly AppDatabaseContext _context;

        public FlashcardSetRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddFlashcardSetAsync(FlashcardSet flashcardSet)
        {
            _context.FlashcardSet.Add(flashcardSet);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardSetAsync(int flashcardSetId)
        {
            var flashcardSet = await _context.FlashcardSet.FindAsync(flashcardSetId);
            _context.FlashcardSet.Remove(flashcardSet);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindFlashcardSetAsync(int flashcardSetId)
        {
            if (await _context.FlashcardSet.FindAsync(flashcardSetId) != null)
                return true;
            return false;
        }

        public async Task<bool> FlashcardSetExistsAsync(int flashcardSetId)
        {
            return await _context.FlashcardSet.AnyAsync(x => x.Id == flashcardSetId);
        }

        public async Task<FlashcardSet> GetFlashcardSetAsync(int flashcardSetId)
        {
            return await _context.FlashcardSet
                .Where(set => set.Id == flashcardSetId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<FlashcardSet> GetFlashcardSetFromDatabaseAsync(int flashcardSetId)
        {
            return await _context.FlashcardSet.FindAsync(flashcardSetId);
        }

        public async Task<List<FlashcardSet>> GetFlashcardSetsAsync()
        {
            return await _context.FlashcardSet
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<FlashcardSet>> GetFlashcardSetsOfCourseAsync(int courseId)
        {
            return await _context.FlashcardSet
                .Where(set=> set.CourseId == courseId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateFlashcardSetAsync(FlashcardSet flashcardSet)
        {
            _context.Entry(flashcardSet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
