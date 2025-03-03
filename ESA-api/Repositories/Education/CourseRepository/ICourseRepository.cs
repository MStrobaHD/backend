﻿using ESA_api.Models;
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
        Task<List<Course>> GetRecommendedCoursesAsync(int userId);
        Task AddCourseAsync(Course course);
        Task EnrolCourse(CourseEnrolment courseEnrolment);
        Task<bool> FindEnrolmentAsync(int userId, int courseId);
        Task DeleteEnrolmentAsync(int userId, int courseId);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int courseId);
        Task<bool> FindCourseAsync(int courseId);
        Task<bool> CourseExistsAsync(int courseId);
        Task<Course> GetCourseFromDatabaseAsync(int courseId);
        Task RateAsync(CourseRating rating);
        Task<List<CourseRating>> GetRateListByIdAsync(int id);
        Task<bool> isRatedAlready(int? courseId, int? userId);
        Task UpdateRatingAsync(CourseRating task);
        Task<CourseRating> GetActualRatingAsync(int courseId, int userId);
    }
}
