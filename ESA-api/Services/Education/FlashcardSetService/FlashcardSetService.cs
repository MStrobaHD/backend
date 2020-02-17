using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.FlashcardSetsDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.FlashcardSerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.FlashcardSetService
{
    public class FlashcardSetService : IFlashcardSetService
    {
        private readonly IFlashcardSetRepository _repository;
        private readonly IMapper _mapper;

        public FlashcardSetService(IFlashcardSetRepository repository, IMapper mapper)
        {
           _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddFlashcardSetAsync(FlashcardSetAddDTO flashcardSetAddDTO)
        {
            var set = _mapper.Map<FlashcardSet>(flashcardSetAddDTO);
            await _repository.AddFlashcardSetAsync(set);
            return set.Id;
        }

        public async Task DeleteFlashcardSetAsync(int setId)
        {
            await _repository.DeleteFlashcardSetAsync(setId);
        }

        public async Task<bool> FindFlashcardSetAsync(int setId)
        {
            if (await _repository.FindFlashcardSetAsync(setId))
                return true;
            return false;
        }

        public async Task<FlashcardSetDTO> GetFlashcardSetAsync(int setId)
        {
            var set = await _repository.GetFlashcardSetAsync(setId);
            return _mapper.Map<FlashcardSetDTO>(set);
        }

        public async Task<List<FlashcardSetListDTO>> GetFlashcardSetsAsync()
        {
            var sets = await _repository.GetFlashcardSetsAsync();
            return _mapper.Map<List<FlashcardSetListDTO>>(sets);
        }

        public async Task<List<FlashcardSetListDTO>> GetFlashcardSetsOfCourseAsync(int courseId)
        {
            var sets = await _repository.GetFlashcardSetsOfCourseAsync(courseId);
            return _mapper.Map<List<FlashcardSetListDTO>>(sets);
        }

        public async Task<int> UpdateFlashcardSetAsync(int setId, FlashcardSetAddDTO flashcardSetAddDTO)
        {
            var examFromDatabase = await _repository.GetFlashcardSetFromDatabaseAsync(setId);
            var examToDatabase = _mapper.Map(flashcardSetAddDTO, examFromDatabase);

            await _repository.UpdateFlashcardSetAsync(examToDatabase);
            return examToDatabase.Id;
        }
    }
}
