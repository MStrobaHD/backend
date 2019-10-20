using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Education.LessonRepository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDatabaseContext _context;

        public LessonRepository(AppDatabaseContext context)
        {
           _context = context;
        }

        public async Task AddCloudAssetAsync(CloudAsset asset)
        {
            _context.CloudAsset.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async  Task AddLessonAsync(Lesson lesson)
        {
            _context.Lesson.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task AddServerAssetAsync(ServerAsset asset)
        {
            _context.ServerAsset.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLessonAsync(int lessonId)
        {
            var lesson = await _context.Exam.FindAsync(lessonId);
            _context.Exam.Remove(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindLessonAsync(int lessonId)
        {
            if (await _context.Exam.FindAsync(lessonId) != null)
                return true;
            return false;
        }

        public async Task<List<Lesson>> GetCourseLessonsAsync(int courseId)
        {
            return await _context.Lesson
                .Where(courseLessons => courseLessons.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Lesson> GetLessonAsync(int lessonId)
        {
            return await _context.Lesson.Where(lesson => lesson.Id == lessonId).SingleOrDefaultAsync();
        }

        public async Task<Lesson> GetLessonFromDatabaseAsync(int lessonId)
        {
            return await _context.Lesson.FindAsync(lessonId);
        }

        public async Task<List<Lesson>> GetLessonsAsync()
        {
            return await _context.Lesson.ToListAsync();
        }

        public async Task<bool> LessonExistsAsync(int lessonId)
        {
            return await _context.Lesson.AnyAsync(x => x.Id == lessonId);
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            _context.Entry(lesson).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
