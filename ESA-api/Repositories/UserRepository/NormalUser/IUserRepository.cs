using ESA_api.Model;
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
        Task<User> GetUserBadgesAsync(int userId);
        Task<User> UpdateUserDataAsync(int userId);
    }
}
