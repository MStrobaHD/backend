using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.FlashcardSerRepository
{
    public interface IFlashcardSetRepository
    {
        Task<List<FlashcardSet>> GetFlashcardSetsAsync();
        Task<List<FlashcardSet>> GetFlashcardSetsOfCourseAsync(int courseId);
        Task<FlashcardSet> GetFlashcardSetAsync(int flashcardSetId);
        Task AddFlashcardSetAsync(FlashcardSet flashcardSet);
        Task UpdateFlashcardSetAsync(FlashcardSet flashcardSet);
        Task DeleteFlashcardSetAsync(int flashcardSetId);
        Task<bool> FindFlashcardSetAsync(int flashcardSetId);
        Task<bool> FlashcardSetExistsAsync(int flashcardSetId);
        Task<FlashcardSet> GetFlashcardSetFromDatabaseAsync(int flashcardSetId);
    }
}
