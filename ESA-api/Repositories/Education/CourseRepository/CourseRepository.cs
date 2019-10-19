using ESA_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.CourseRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDatabaseContext _context;

        public CourseRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddCourseAsync(Course course)
        {
            _context.Course.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CourseExistsAsync(int courseId)
        {
            return await _context.Course.AnyAsync(x => x.Id == courseId);
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            var course = await _context.Course.FindAsync(courseId);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindCourseAsync(int courseId)
        {
            if (await _context.Course.FindAsync(courseId) != null)
                return true;
            return false;
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _context.Course.Where(course => course.Id == courseId).SingleOrDefaultAsync();
        }

        public async Task<Course> GetCourseFromDatabaseAsync(int courseId)
        {
            return await _context.Course.FindAsync(courseId);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Course.ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _context.Course.Where(course => course.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Course>> GetCoursesCreatedByUserAsync(int userId)
        {
            return await _context.Course.Where(course => course.UserId == userId).ToListAsync();
        }
     
        public async Task<User> GetEnrolmentCoursesAsync(int userId)   //TODO Przenieść do innego repozytorium
        {
            return await _context.User
                .Include(course => course.CourseEnrolment)
                .Include(courseEnrolment => courseEnrolment.Course).SingleOrDefaultAsync();
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
