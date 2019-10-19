using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Model;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Education.ExamRepository
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDatabaseContext _context;

        public ExamRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddExamAsync(Exam exam)
        {
            _context.Exam.Add(exam);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExamAsync(int examId)
        {
            var exam = await _context.Exam.FindAsync(examId);
            _context.Exam.Remove(exam);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExamExistsAsync(int examId)
        {
            return await _context.Exam.AnyAsync(x => x.Id == examId);
        }

        public async Task<bool> FindExamAsync(int examId)
        {
            if (await _context.Exam.FindAsync(examId) != null)
                return true;
            return false;
        }

        public async Task<List<Exam>> GetCourseExamsAsync(int courseId)
        {
            return await _context.Exam
                .Where(courseExams => courseExams.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Exam> GetExamAsync(int examId)
        {
            return await _context.Exam.Where(exam => exam.Id == examId).SingleOrDefaultAsync();
        }

        public async Task<Exam> GetExamFromDatabaseAsync(int examId)
        {
            return await _context.Exam.FindAsync(examId);
        }

        public async Task<List<Exam>> GetExamsAsync()
        {
            return await _context.Exam.ToListAsync();
        }

        public async Task<List<Exam>> GetExamsByTypeAsync(int examTypeId)
        {
            return await _context.Exam.Where(exam => exam.ExamTypeId == examTypeId).ToListAsync();
        }

        public async Task<Exam> GetMultiSelectQuestionsOfExam(int examId)
        {
            return await _context.Exam
               .Where(exam => exam.Id == examId)
               .Include(exam => exam.MultiSelectQuestion)
               .SingleOrDefaultAsync();
        }

        public async Task<Exam> GetOrderedBlocksOfExam(int examId)
        {
            return await _context.Exam
               .Where(exam => exam.Id == examId)
               .Include(exam => exam.OrderedBlock)
               .SingleOrDefaultAsync();
        }

        public async Task<Exam> GetQuestionsOfExam(int examId)
        {
            return await _context.Exam
               .Where(exam => exam.Id == examId)
               .Include(exam => exam.Question)
               .SingleOrDefaultAsync();
        }

        public async Task UpdateExamAsync(Exam exam)
        {
            _context.Entry(exam).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
