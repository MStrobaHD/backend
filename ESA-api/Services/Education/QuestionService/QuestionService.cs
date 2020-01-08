using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using ESA_api.Model;
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
            multiSelectQuestionAddDTO.OptionFour = multiSelectQuestionAddDTO.CorrectAnswer;
            var multiSelectQuestion = _mapper.Map<MultiSelectQuestion>(multiSelectQuestionAddDTO);
            await _repository.AddMultiSelectQuestionAsync(multiSelectQuestion);
            return multiSelectQuestion.Id;
        }

        public async Task<int> AddOrderedBlockAsync(OrderedBlockAddDTO orderedBlockAddDTO)
        {
            var orderedBlock = _mapper.Map<OrderedBlock>(orderedBlockAddDTO);
            await _repository.AddOrderedBlockAsync(orderedBlock);
            return orderedBlock.Id;
        }

        public async Task<int> AddQuestionAsync(QuestionAddDTO questionAddDTO)
        {
            var question = _mapper.Map<Question>(questionAddDTO);
            await _repository.AddQuestionAsync(question);
            return question.Id;
        }

        public async Task<List<MultiSelectQuestionListDTO>> GetMultiSelectQuestionsFromExamAsync(int examId)
        {
            var questions = await _repository.GetMultiSelectQuestionsFromExamAsync(examId);
            return _mapper.Map<List<MultiSelectQuestionListDTO>>(questions);
        }

        public async Task<List<OrderedBlockListDTO>> GetOrderedBlocksFromExamAsync(int examId)
        {
            var questions = await _repository.GetOrderedBlocksFromExamAsync(examId);
            return _mapper.Map<List<OrderedBlockListDTO>>(questions);
        }

        public async Task<List<QuestionListDTO>> GetQuestionsFromExamAsync(int examId)
        {
            var questions = await _repository.GetQuestionsFromExamAsync(examId);
            return _mapper.Map<List<QuestionListDTO>>(questions);
        }
    }
}
