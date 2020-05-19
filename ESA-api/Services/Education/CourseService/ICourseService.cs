using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EnrolmentDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.CourseService
{
    public interface ICourseService
    {
        Task<List<CourseListDTO>> GetCoursesAsync();
        Task<CourseDTO> GetCourseAsync(int id);
        Task<List<CourseEnlistedDTO>> GetEnroledCoursesAsync(int userId);
        Task<List<CourseEnlistedDTO>> GetNoEnroledCoursesAsync(int userId);
        Task<List<CourseListDTO>> GetCoursesCreatedByUserAsync(int userId);
        Task<List<CourseListDTO>> GetCoursesByCategoryAsync(int categoryId);
        Task<int> AddCourseAsync(CourseAddDTO courseAddDTO);
        Task<int> EnrolCourse(EnlistParametersDTO enlistParametersDTO);
        Task<bool> EnrolmentExistAsync(EnlistParametersDTO enlistParametersDTO);
        Task DeleteEnrolmentAsync(int userId, int courseId);
        Task<int> UpdateCourseAsync(int courseId, CourseAddDTO courseAddDTO);
        Task DeleteCourseAsync(int courseId);
        Task<bool> FindCourseAsync(int courseId);
        Task<bool> CourseExistsAsync(int courseId);
        Task<int> RateAsync(CourseRatingDTO ratingDTO);
    }
}
