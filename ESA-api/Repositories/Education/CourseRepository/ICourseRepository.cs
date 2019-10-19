using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.CourseRepository
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesAsync();
        Task<Course> GetCourseAsync(int courseId);
        Task<User> GetEnrolmentCoursesAsync(int userId);
        Task<List<Course>> GetCoursesCreatedByUserAsync(int userId);
        Task<List<Course>> GetCoursesByCategoryAsync(int categoryId);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
        Task<bool> FindCourseAsync(int courseId);
        Task<bool> CourseExistsAsync(int courseId);
        Task<Course> GetCourseFromDatabaseAsync(int courseId);
    }
}
