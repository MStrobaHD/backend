using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.QuestionService
{
    public interface IQuestionService
    {
        Task<int> AddQuestionAsync(QuestionAddDTO questionAddDTO);
        Task<int> AddMultiSelectQuestionAsync(MultiSelectQuestionAddDTO multiSelectQuestionAddDTO);
        Task<int> AddOrderedBlockAsync(OrderedBlockAddDTO orderedBlockAddDTO );
        Task<List<QuestionListDTO>> GetQuestionsFromExamAsync(int examId);
        Task<List<MultiSelectQuestionListDTO>> GetMultiSelectQuestionsFromExamAsync(int examId);
        Task<List<OrderedBlockListDTO>> GetOrderedBlocksFromExamAsync(int examId);

        //Task<ExamDTO> GetExamAsync(int id);
        //Task<List<ExamListDTO>> GetCourseExamsAsync(int courseId);
        //// Task<List<ExamListDTO>> GetExamsByTypeAsync(int examTypeId);
        //Task<int> AddExamAsync(ExamAddDTO examAddDTO);
        //Task<int> UpdateExamAsync(int examId, ExamAddDTO examAddDTO);
        //Task DeleteExamAsync(int examId);
        //Task<bool> FindExamAsync(int examId);

        //Task<List<Question>> GetQuestionsAsync();
        //Task<Question> GetQuestionAsync(int questionId);
        //Task<List<Question>> GetQuestionsFromExamAsync(int examId);
        //Task AddQuestionAsync(Question question);
        //Task UpdateQuestionAsync(Question question);
        //Task DeleteQuestionAsync(int questionId);
        //Task<bool> FindQuestionAsync(int qestionId);
        //Task<bool> QuestionExistsAsync(int questionId);
        //Task<Question> GetQuestionFromDatabaseAsync(int questionId);

        //// Multi select question
        //Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsAsync();
        //Task<MultiSelectQuestion> GetMultiSelectQuestionAsync(int multiSelectQuestionId);
        //Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsFromExamAsync(int examId);
        //Task AddMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion);
        //Task UpdateMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion);
        //Task DeleteMultiSelectQuestionAsync(int multiSelectQuestionId);
        //Task<bool> FindMultiSelectQuestionAsync(int multiSelectQuestionId);
        //Task<bool> MultiSelectQuestionExistsAsync(int multiSelectQuestionId);
        //Task<MultiSelectQuestion> GetMultiSelectQuestionFromDatabaseAsync(int multiSelectQuestionId);

        //// Ordered block
        //Task<List<OrderedBlock>> GetOrderedBlocksAsync();
        //Task<OrderedBlock> GetOrderedBlockAsync(int OrderedBlockId);
        //Task<List<OrderedBlock>> GetOrderedBlocksFromExamAsync(int examId);
        //Task AddOrderedBlockAsync(OrderedBlock OrderedBlock);
        //Task UpdateOrderedBlockAsync(OrderedBlock OrderedBlock);
        //Task DeleteOrderedBlockAsync(int OrderedBlockId);
        //Task<bool> FindOrderedBlockAsync(int OrderedBlockId);
        //Task<bool> OrderedBlockExistsAsync(int OrderedBlockId);
        //Task<OrderedBlock> GetOrderedBlockFromDatabaseAsync(int OrderedBlockId);
    }
}
