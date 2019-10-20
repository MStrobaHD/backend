using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.QuestionRepository;

namespace ESA_api.Services.Education.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddMultiSelectQuestionAsync(MultiSelectQuestionAddDTO multiSelectQuestionAddDTO)
        {
            var multiSelectQuestion = _mapper.Map<MultiSelectQuestion>(multiSelectQuestionAddDTO);
            await _repository.AddMultiSelectQuestionAsync(multiSelectQuestion);
            return multiSelectQuestion.Id;
        }

        public async Task<int> AddOrderedBlockAsync(OrderedBlockAddDTO orderedBlockAddDTO)
        {
            var orderedBlock = _mapper.Map<MultiSelectQuestion>(orderedBlockAddDTO);
            await _repository.AddMultiSelectQuestionAsync(orderedBlock);
            return orderedBlock.Id;
        }

        public async Task<int> AddQuestionAsync(QuestionAddDTO questionAddDTO)
        {
            var question = _mapper.Map<MultiSelectQuestion>(questionAddDTO);
            await _repository.AddMultiSelectQuestionAsync(question);
            return question.Id;
        }
    }
}
