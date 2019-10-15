using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Models;
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
            courseAddDTO.Date = DateTime.Now;
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

        public async Task<int> UpdateCourseAsync(int courseId, CourseAddDTO courseAddDTO)
        {
            var courseFromDatabase = await _repository.GetCourseFromDatabaseAsync(courseId);
            var courseToDatabase =  _mapper.Map(courseAddDTO, courseFromDatabase);

            await _repository.UpdateCourseAsync(courseToDatabase);
            return courseToDatabase.Id;
        }
    }
}
