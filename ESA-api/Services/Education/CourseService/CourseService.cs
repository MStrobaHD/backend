using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EnrolmentDTO;
using ESA_api.Model;
using ESA_api.Repositories.Education.CourseRepository;

namespace ESA_api.Services.Education.CourseService
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddCourseAsync(CourseAddDTO courseAddDTO)
        {
           
            var course = _mapper.Map<Course>(courseAddDTO);
            await _repository.AddCourseAsync(course);
            return course.Id;
        }

        public Task<bool> CourseExistsAsync(int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCourseAsync(int courseId)
        {
            await _repository.DeleteCourseAsync(courseId);
        }

        public async Task DeleteEnrolmentAsync(int userId, int courseId)
        {
            await _repository.DeleteEnrolmentAsync(userId, courseId);
        }

        public async Task<int> EnrolCourse(EnlistParametersDTO enlistParametersDTO)
        {
            enlistParametersDTO.EnrolmentDate = DateTime.Now;
            var enrolment = _mapper.Map<CourseEnrolment>(enlistParametersDTO);
            await _repository.EnrolCourse(enrolment);
            return enrolment.Id;
        }

        public async Task<bool> EnrolmentExistAsync(EnlistParametersDTO enlistParametersDTO)
        {
            return await _repository.FindEnrolmentAsync(enlistParametersDTO.UserId, enlistParametersDTO.CourseId);
        }

        public async Task<bool> FindCourseAsync(int courseId)
        {
            if (await _repository.FindCourseAsync(courseId))
                return true;
            return false;
        }

        public async Task<CourseDTO> GetCourseAsync(int id)
        {
            var course = await _repository.GetCourseAsync(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task<List<CourseListDTO>> GetCoursesAsync()
        {
            var course = await _repository.GetCoursesAsync();
            return _mapper.Map<List<CourseListDTO>>(course);
        }

        public async Task<List<CourseListDTO>> GetCoursesByCategoryAsync(int categoryId)
        {
            var course = await _repository.GetCoursesByCategoryAsync(categoryId);
            return _mapper.Map<List<CourseListDTO>>(course);
        }

        public async Task<List<CourseListDTO>> GetCoursesCreatedByUserAsync(int userId)
        {
            var course = await _repository.GetCoursesCreatedByUserAsync(userId);
            return _mapper.Map<List<CourseListDTO>>(course);
        }

        public async Task<List<CourseEnlistedDTO>> GetEnroledCoursesAsync(int userId)
        {
            var user = await _repository.GetEnrolmentCoursesAsync(userId);

            List<Course> enlistedCourses = new List<Course>();
            foreach (var enrolment in user.CourseEnrolment)
            {
                enlistedCourses.Add(enrolment.Course);
            }

            return _mapper.Map<List<CourseEnlistedDTO>>(enlistedCourses);
        }

        public async Task<List<CourseEnlistedDTO>> GetNoEnroledCoursesAsync(int userId)
        {
            List<CourseEnlistedDTO> noEnroledCourses = new List<CourseEnlistedDTO>();
            var user = await _repository.GetEnrolmentCoursesAsync(userId);

            List<Course> enlistedCourses = new List<Course>();
            foreach (var enrolment in user.CourseEnrolment)
            {
                enlistedCourses.Add(enrolment.Course);
            }

            var allCourses = await _repository.GetCoursesAsync();
            var mappedenlisted = _mapper.Map<List<CourseEnlistedDTO>>(enlistedCourses);
            var mappedAllCourses = _mapper.Map<List<CourseEnlistedDTO>>(allCourses);

            foreach (var course in mappedAllCourses)
            {
                
                    if (mappedenlisted.Any(courseExist => courseExist.Id == course.Id))
                    {
                    //return mappedenlisted;
                    } else
                    {
                        noEnroledCourses.Add(course);
                    }
                
            }
            return _mapper.Map<List<CourseEnlistedDTO>>(noEnroledCourses);
        }

        public async Task<int> UpdateCourseAsync(int courseId, CourseAddDTO courseAddDTO)
        {
            var courseFromDatabase = await _repository.GetCourseFromDatabaseAsync(courseId);
            var courseToDatabase =  _mapper.Map(courseAddDTO, courseFromDatabase);

            await _repository.UpdateCourseAsync(courseToDatabase);
            return courseToDatabase.Id;
        }
    }
}
