using ESA_api.Mapping.DTO.EducationDTO.FlashcardSetsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.FlashcardSetService
{
    public interface IFlashcardSetService
    {
        Task<List<FlashcardSetListDTO>> GetFlashcardSetsAsync();
        Task<List<FlashcardSetListDTO>> GetFlashcardSetsOfCourseAsync(int courseId);
        Task<FlashcardSetDTO> GetFlashcardSetAsync(int setId);
        Task<int> AddFlashcardSetAsync(FlashcardSetAddDTO flashcardSetAddDTO);
        Task<int> UpdateFlashcardSetAsync(int setId, FlashcardSetAddDTO flashcardSetAddDTO);
        Task DeleteFlashcardSetAsync(int setId);
        Task<bool> FindFlashcardSetAsync(int setId);
    }
}
