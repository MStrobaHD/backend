using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Model;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Education.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDatabaseContext _context;

        public QuestionRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion)
        {
            _context.MultiSelectQuestion.Add(multiSelectQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task AddOrderedBlockAsync(OrderedBlock orderedBlock)
        {
            _context.OrderedBlock.Add(orderedBlock);
            await _context.SaveChangesAsync();
        }

        public async Task AddQuestionAsync(Question question)
        {
            _context.Question.Add(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMultiSelectQuestionAsync(int multiSelectQuestionId)
        {
            var multiSelectQuestion = await _context.MultiSelectQuestion.FindAsync(multiSelectQuestionId);
            _context.MultiSelectQuestion.Remove(multiSelectQuestion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderedBlockAsync(int orderedBlockId)
        {
            var orderedBlock = await _context.OrderedBlock.FindAsync(orderedBlockId);
            _context.OrderedBlock.Remove(orderedBlock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            var question = await _context.Question.FindAsync(questionId);
            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindMultiSelectQuestionAsync(int multiSelectQuestionId)
        {
            if (await _context.MultiSelectQuestion.FindAsync(multiSelectQuestionId) != null)
                return true;
            return false;
        }

        public async Task<bool> FindOrderedBlockAsync(int orderedBlockId)
        {
            if (await _context.OrderedBlock.FindAsync(orderedBlockId) != null)
                return true;
            return false;
        }

        public async Task<bool> FindQuestionAsync(int qestionId)
        {
            if (await _context.Question.FindAsync(qestionId) != null)
                return true;
            return false;
        }

        public async Task<MultiSelectQuestion> GetMultiSelectQuestionAsync(int multiSelectQuestionId)
        {
            return await _context.MultiSelectQuestion.Where(multiSelectQuestion => multiSelectQuestion.Id == multiSelectQuestionId).SingleOrDefaultAsync();
        }

        public async Task<MultiSelectQuestion> GetMultiSelectQuestionFromDatabaseAsync(int multiSelectQuestionId)
        {
            return await _context.MultiSelectQuestion.FindAsync(multiSelectQuestionId);
        }

        public async Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsAsync()
        {
            return await _context.MultiSelectQuestion.ToListAsync();
        }

        public async Task<List<MultiSelectQuestion>> GetMultiSelectQuestionsFromExamAsync(int examId)
        {
            return await _context.MultiSelectQuestion
                .Where(question => question.ExamId==examId)
                .ToListAsync();
        }

        public async Task<OrderedBlock> GetOrderedBlockAsync(int orderedBlockId)
        {
            return await _context.OrderedBlock.Where(orderedBlock => orderedBlock.Id == orderedBlockId).SingleOrDefaultAsync();
        }

        public async Task<OrderedBlock> GetOrderedBlockFromDatabaseAsync(int orderedBlockId)
        {
            return await _context.OrderedBlock.FindAsync(orderedBlockId);
        }

        public async Task<List<OrderedBlock>> GetOrderedBlocksAsync()
        {
            return await _context.OrderedBlock.ToListAsync();
        }

        public async Task<List<OrderedBlock>> GetOrderedBlocksFromExamAsync(int examId)
        {
            return await _context.OrderedBlock
                .Where(question => question.ExamId == examId)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionAsync(int questionId)
        {
            return await _context.Question.Where(question => question.Id == questionId).SingleOrDefaultAsync();
        }

        public async Task<Question> GetQuestionFromDatabaseAsync(int questionId)
        {
            return await _context.Question.FindAsync(questionId);
        }

        public async Task<List<Question>> GetQuestionsAsync()
        {
            return await _context.Question.ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsFromExamAsync(int examId)
        {
            return await _context.Question
               .Where(question => question.ExamId == examId)
               .ToListAsync();
        }

        public async Task<bool> MultiSelectQuestionExistsAsync(int multiSelectQuestionId)
        {
            return await _context.MultiSelectQuestion.AnyAsync(x => x.Id == multiSelectQuestionId);
        }

        public async Task<bool> OrderedBlockExistsAsync(int orderedBlockId)
        {
            return await _context.OrderedBlock.AnyAsync(x => x.Id == orderedBlockId);
        }

        public async Task<bool> QuestionExistsAsync(int questionId)
        {
            return await _context.Question.AnyAsync(x => x.Id == questionId);
        }

        public async Task UpdateMultiSelectQuestionAsync(MultiSelectQuestion multiSelectQuestion)
        {
            _context.Entry(multiSelectQuestion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderedBlockAsync(OrderedBlock orderedBlock)
        {
            _context.Entry(orderedBlock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
