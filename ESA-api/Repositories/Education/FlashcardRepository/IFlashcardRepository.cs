using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.FlashcardRepository
{
    public interface IFlashcardRepository
    {
        Task<FlashcardSet> GetFlashcardsListAsync(int id);
        Task<List<Flashcard>> GetSetFlashcardsListAsync(int setId);
        Task DeleteFlashcardAsync(int flashcardId);
        Task<bool> FindFlashcardAsync(int flashcardId);
        Task AddFlashcardAsync(Flashcard flashcard);
    }
}
