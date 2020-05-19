using ESA_api.Mapping.DTO.CommonDTO.CategorysDTO;
using ESA_api.Models;
using ESA_api.Repositories.Common.CategoryRepository;
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
        private readonly ICategoryRepository _repository;

        public CourseRepository(AppDatabaseContext context, ICategoryRepository repository)
        {
            _context = context;
           _repository = repository;
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

        public async Task DeleteEnrolmentAsync(int userId, int courseId)
        {
            var enrolment = await _context.CourseEnrolment.Where(course => course.UserId == userId & course.CourseId == courseId).SingleOrDefaultAsync();
            _context.CourseEnrolment.Remove(enrolment);
            await _context.SaveChangesAsync();
        }

        public async Task EnrolCourse(CourseEnrolment courseEnrolment)
        {
            _context.CourseEnrolment.Add(courseEnrolment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FindCourseAsync(int courseId)
        {
            if (await _context.Course.FindAsync(courseId) != null)
                return true;
            return false;
        }

        public async Task<bool> FindEnrolmentAsync(int userId, int courseId)
        {
            return await _context.CourseEnrolment.AnyAsync(enrolment => enrolment.UserId == userId & enrolment.CourseId == courseId);
        }

        public async Task<CourseRating> GetActualRatingAsync(int courseId, int userId)
        {
            return await _context.CourseRating.Where(exp => exp.CourseId == courseId && exp.UserId == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<Course> GetCourseAsync(int courseId)
        {
            return await _context.Course.Where(course => course.Id == courseId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<Course> GetCourseFromDatabaseAsync(int courseId)
        {
            return await _context.Course.FindAsync(courseId);
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Course
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByCategoryAsync(int categoryId)
        {
            return await _context.Course.Where(course => course.CategoryId == categoryId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetCoursesCreatedByUserAsync(int userId)
        {
            return await _context.Course.Where(course => course.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
     
        public async Task<User> GetEnrolmentCoursesAsync(int userId)   //TODO Przenieść do innego repozytorium
        {
            return await _context.User
                .Include(course => course.CourseEnrolment)
                .ThenInclude(courseEnrolment => courseEnrolment.Course).Where(course => course.Id == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<CourseRating>> GetRateListByIdAsync(int id)
        {
            return await _context.CourseRating.Where(rate => rate.CourseId == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Course>> GetRecommendedCoursesAsync(int userId)
        {
            var coursesEnlistedByUser = await GetEnrolmentCoursesAsync(userId);
            var categories = await _repository.GetCategoriesAsync();
            int categoryCounter = 0;

            List<Course> enlistedCourses = new List<Course>();
            List<CategoryIdDTO> category = new List<CategoryIdDTO>();

            foreach (var enrolment in coursesEnlistedByUser.CourseEnrolment)
            {
                enlistedCourses.Add(enrolment.Course);
            }

            foreach(var categoryItem in categories)
            {
                foreach(var categorizedCourse in enlistedCourses)
                {
                    if(categorizedCourse.CategoryId == categoryItem.Id)
                    {
                        categoryCounter++;
                    }
                }
                CategoryIdDTO item = new CategoryIdDTO();
                item.Id = categoryItem.Id;
                item.Count = categoryCounter;
                category.Add(item);
            }
            // poprawic to gówno
            // jesli nie pierwsza kategoria to nastepna i tak ojebania wszyzstkich kategorii
            // dodać współczynnik zainteresowania -> najczesciej wybierane kursy
            // + w danym przedziale wiekowym
            // 
            category.Sort();
            var choosen = category.First();

            // pobrac kursy na które nie jest zapisany uzytkownik
            // a z nich te które wskaże wspołczynnik zaiteresowania

          
            return enlistedCourses;
        }

        public async Task<bool> isRatedAlready(int? courseId, int? userId)
        {
            var rating = await _context.CourseRating.Where(exp => exp.CourseId == courseId && exp.UserId == userId).SingleOrDefaultAsync();

            if (rating != null)
                return true;
            return false;
        }

        public async Task RateAsync(CourseRating rating)
        {
            _context.CourseRating.Add(rating);
            await _context.SaveChangesAsync(); ;
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRatingAsync(CourseRating task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
