using ESA_api.Mapping.DTO.EducationDTO.FlashcardsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.FlashcardService
{
   public interface IFlashcardService
    {
        Task<FlashcardSetForFlashcardDTO> GetFlashcardsListAsync(int id);
        Task<List<FlashcardDTO>> GetSetFlashcardsListAsync(int setId);
        Task DeleteFlashcardAsync(int flashcardId);
        Task<bool> FindFlashcardAsync(int flashcardId);
        Task<int> AddFlashcardAsync(FlashcardAddDTO flashcardAddDTO);
    }
}
