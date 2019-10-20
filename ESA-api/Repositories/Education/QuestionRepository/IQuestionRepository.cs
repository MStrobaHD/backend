using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.QuestionRepository
{
    public interface IQuestionRepository
    {
        // Single question
        Task<List<Question>> GetQuestionsAsync();
        Task<Question> GetQuestionAsync(int questionId);
        Task<List<Question>> GetQuestionsFromExamAsync(int examId); 
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(Question question);
        Task DeleteQuestionAsync(int questionId);
        Task<bool> FindQuestionAsync(int qestionId);
        Task<bool> QuestionExistsAsync(int questionId);
        Task<Question> GetQuestionFromDatabaseAsync(int questionId);

        // Multi select question
        Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsAsync();
        Task<MultiSelectQuestion> GetMultiSelectQuestionAsync(int multiSelectQuestionId);
        Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsFromExamAsync(int examId);
        Task AddMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion);
        Task UpdateMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion);
        Task DeleteMultiSelectQuestionAsync(int multiSelectQuestionId);
        Task<bool> FindMultiSelectQuestionAsync(int multiSelectQuestionId);
        Task<bool> MultiSelectQuestionExistsAsync(int multiSelectQuestionId);
        Task<MultiSelectQuestion> GetMultiSelectQuestionFromDatabaseAsync(int multiSelectQuestionId);

        // Ordered block
        Task<List<OrderedBlock>> GetOrderedBlocksAsync();
        Task<OrderedBlock> GetOrderedBlockAsync(int OrderedBlockId);
        Task<List<OrderedBlock>> GetOrderedBlocksFromExamAsync(int examId);
        Task AddOrderedBlockAsync(OrderedBlock OrderedBlock);
        Task UpdateOrderedBlockAsync(OrderedBlock OrderedBlock);
        Task DeleteOrderedBlockAsync(int OrderedBlockId);
        Task<bool> FindOrderedBlockAsync(int OrderedBlockId);
        Task<bool> OrderedBlockExistsAsync(int OrderedBlockId);
        Task<OrderedBlock> GetOrderedBlockFromDatabaseAsync(int OrderedBlockId);
    }
}
