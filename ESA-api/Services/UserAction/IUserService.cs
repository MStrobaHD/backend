using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.CommonDTO.BadgeAssignmentDTO;
using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Mapping.DTO.CommonDTO.ExperienceDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.UserAction
{
    public interface IUserService
    {
        Task<UserDTO> GetUserDataAsync(int userId);
        Task<List<UserDTO>> GetUsersAsync();
        Task<int> UpdateUserAsync(int id, UserDTO userDTO);
        Task<int> UpdateUserRoleAsync(User user);
        Task<int> UpdateUserGroupRoleAsync(List<User> users);
        Task AddBadgeAsync(BadgeAddDTO badgeAddDTO);
        Task AssignBadgeAsync(BadgeAssignmentAddDTO badgeAssignmentAddDTO);
        Task<List<BadgeDTO>> GetAllBadgesAsync();
        Task<List<BadgeDTO>> GetUserAssignedBadgesAsync(int userId);
        Task<int> AddOrUpdateExperienceAsync(ExperienceAddDTO experienceAddDTO);
        Task<int> GetExperiencePoints();
        Task<UserStatistics> GetUserStatisticsAsync();
        Task<MarksStatistics> GetUserMarkStatisticsAsync(int userId);
        Task<MarksStatistics> GetAllMarkStatisticsAsync();
        Task<VerdictsStatistics> GetUserVerdictsStatisticsAsync(int userId);
        Task<VerdictsStatistics> GetAllVerdictsStatisticsAsync();
        Task<AssetsStatistics> GetAssetsStatisticsAsync();

    }
}
