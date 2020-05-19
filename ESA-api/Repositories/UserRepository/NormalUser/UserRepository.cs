using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.Custom;
using ESA_api.Models;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.UserRepository.NormalUser
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDatabaseContext _context;

        public UserRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserDataAsync(int userId)
        {
            return await _context.User
                .Where(user => user.Id == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public Task<User> GetUserMarksAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserStatisticsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserVerdictAsync(int userId)
        {
            return await _context.User.Include(x => x.Verdict)
                .Where(user => user.Id == userId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task UpdateUserDataAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetUserFromBaseAsync(int id)
        {
            var userToBase = await _context.User.FindAsync(id);
            return userToBase;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateUserRoleAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Badge>> GetAllBadgesAsync()
        {
            return await _context.Badge
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetUserAssignedBadges(int userId)
        {
            return await _context.User.Where(user => user.Id == userId)
                .Include(badgeAssignment => badgeAssignment.BadgeAssignment)
                .ThenInclude(badge => badge.Badge)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task AddBadgeAsync(Badge badge)
        {
            _context.Badge.Add(badge);
            await _context.SaveChangesAsync();
        }

        public async Task AssignBadgeAsync(BadgeAssignment badgeAssignment)
        {
             _context.BadgeAssignment.Add(badgeAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task AddExperienceAsync(Experience experience)
        {
            _context.Experience.Add(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetActualExperience(Experience experience)
        {
            var experienceFromDB = await _context.Experience.SingleOrDefaultAsync();
            return experienceFromDB.ExperiencePoints;
        }

        public async Task UpdateExperienceAsync(Experience experience)
        {
            _context.Entry(experience).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCategoryId(int examId)
        {
            var exam = await _context.Exam.FindAsync(examId);
            var course = await _context.Course.FindAsync(exam.CourseId);
            return course.CategoryId;
        }

        public async Task<bool> FindExperienceAsync(int userId, int categoryId)
        {

            var experience = await _context.Experience.Where(exp => exp.CategoryId == categoryId && exp.UserId == userId).SingleOrDefaultAsync();

            if (experience != null)
                return true;
            return false;

        }
        public async Task<Experience> GetExperienceAsync(int userId, int categoryId)
        {

            var experience = await _context.Experience.Where(exp => exp.CategoryId == categoryId && exp.UserId == userId).SingleOrDefaultAsync();

            return experience;

        }

        public async Task<Badge> GetBadgeAsync(int badgeId)
        {
            return await _context.Badge.FindAsync(badgeId);
        }

        public async Task<List<Verdict>> GetAllVerdictAsync()
        {
            return await _context.Verdict.ToListAsync();
        }

        public async Task<int> CountCoursesAsync()
        {
            return await _context.Course.CountAsync();
        }

        public async Task<int> CountExamsAsync()
        {
            return await _context.Exam.CountAsync();
        }

        public async Task<int> CountLessonsAsync()
        {
            return await _context.Lesson.CountAsync();
        }

        public async Task<int> CountAlgorithmsAsync()
        {
            return await _context.AlgorithmTask.CountAsync();
        }

        public async Task<int> CountFlashcardSetsAsync()
        {
            return await _context.FlashcardSet.CountAsync();
        }
    }
}
