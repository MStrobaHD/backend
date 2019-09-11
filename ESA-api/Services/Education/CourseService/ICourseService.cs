using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.CourseService
{
    public interface ICourseService
    {
        Task<List<CourseListDTO>> GetCoursesAsync();
        Task<CourseDTO> GetCourseAsync(int id);
        Task<List<CourseListDTO>> GetCoursesCreatedByUserAsync(int userId);
        Task<List<CourseListDTO>> GetCoursesByCategoryAsync(int categoryId);
        Task<int> AddCourseAsync(CourseAddDTO courseAddDTO);
        Task<int> UpdateCourseAsync(int courseId, CourseAddDTO courseAddDTO);
        Task DeleteCourseAsync(int courseId);
        Task<bool> FindCourseAsync(int courseId);
        Task<bool> CourseExistsAsync(int courseId);
    }
}
