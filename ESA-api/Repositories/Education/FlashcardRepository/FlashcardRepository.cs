using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.FlashcardRepository
{
    public class FlashcardRepository : IFlashcardRepository
    {
        private readonly AppDatabaseContext _context;

        public FlashcardRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddFlashcardAsync(Flashcard flashcard)
        {
            _context.Flashcard.Add(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlashcardAsync(int flashcardId)
        {
            var flashcard = await _context.Flashcard.FindAsync(flashcardId);

            _context.Flashcard.Remove(flashcard);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindFlashcardAsync(int flashcardId)
        {
            if (await _context.Flashcard.FindAsync(flashcardId) != null)
                return true;
            return false;
        }

        public async Task<FlashcardSet> GetFlashcardsListAsync(int id)
        {
            return await _context.FlashcardSet.Include(flash => flash.Flashcard).Where(flashcard => flashcard.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Flashcard>> GetSetFlashcardsListAsync(int setId)
        {
            return await _context.Flashcard.Where(flashcard => flashcard.FlashcardSetId == setId).ToListAsync();
        }
    }
}

