using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.UserRepository.NormalUser
{
    public interface IUserRepository
    {
        Task<User> GetUserDataAsync(int userId);
        Task<User> GetUserStatisticsAsync(int userId);
        Task<User> GetUserMarksAsync(int userId);
        Task<User> GetUserVerdictAsync(int userId);
        Task<List<Verdict>> GetAllVerdictAsync();
        Task UpdateUserDataAsync(User user);
        Task UpdateUserRoleAsync(User user);
        Task<User> GetUserFromBaseAsync(int id);
        Task<List<User>> GetUsersAsync();
        Task<List<Badge>> GetAllBadgesAsync();
        Task<User> GetUserAssignedBadges(int userId);
        Task AddBadgeAsync(Badge badge);
        Task<Badge> GetBadgeAsync(int badgeId);
        Task AssignBadgeAsync(BadgeAssignment badgeAssignment);
        Task AddExperienceAsync(Experience experience);
        Task UpdateExperienceAsync(Experience experience);
        Task<int> GetActualExperience(Experience experience);
        Task<bool> FindExperienceAsync(int userId, int categoryId);
        Task<Experience> GetExperienceAsync(int userId, int categoryId);
        Task<int> GetCategoryId(int examId);
        Task<int> CountCoursesAsync();
        Task<int> CountExamsAsync();
        Task<int> CountLessonsAsync();
        Task<int> CountAlgorithmsAsync();
        Task<int> CountFlashcardSetsAsync();


    }
}
