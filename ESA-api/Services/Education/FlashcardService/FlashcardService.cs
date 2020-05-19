using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.FlashcardsDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.FlashcardRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.FlashcardService
{
    public class FlashcardService : IFlashcardService
    {
        private readonly IFlashcardRepository _repository;
        private readonly IMapper _mapper;
        public FlashcardService(IFlashcardRepository repository, IMapper mapper)
        {
           _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddFlashcardAsync(FlashcardAddDTO flashcardAddDTO)
        {
            var flashcardToAdd = _mapper.Map<Flashcard>(flashcardAddDTO);
            await _repository.AddFlashcardAsync(flashcardToAdd);
            return flashcardToAdd.Id;
        }

        public async Task DeleteFlashcardAsync(int flashcardId)
        {
            await _repository.DeleteFlashcardAsync(flashcardId);
        }

        public async Task<bool> FindFlashcardAsync(int flashcardId)
        {
            if (await _repository.FindFlashcardAsync(flashcardId) != false)
                return true;
            return false;
        }

        public async Task<FlashcardSetForFlashcardDTO> GetFlashcardsListAsync(int id)
        {
            var flashcard = await _repository.GetFlashcardsListAsync(id);
            return _mapper.Map<FlashcardSetForFlashcardDTO>(flashcard);
        }

        public async Task<List<FlashcardDTO>> GetSetFlashcardsListAsync(int setId)
        {
            var flashcard = await _repository.GetSetFlashcardsListAsync(setId);
            return _mapper.Map<List<FlashcardDTO>>(flashcard);
        }
    }
}
