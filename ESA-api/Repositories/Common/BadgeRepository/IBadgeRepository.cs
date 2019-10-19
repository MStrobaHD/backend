using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.BadgeRepository
{
    public interface IBadgeRepository
    {
        Task<List<Badge>> GetBadgesAsync();
        Task<Badge> GetBadgeAsync(int badgeId);
        Task<Badge> GetAssignedBadgesAsync(int userId);
        Task AddBadgeAsync(Badge badge);
        Task DeleteBadgeAsync(int badgeId);
        Task<bool> FindBadgeAsync(int badgeId);
        Task<Badge> UpdateBadgeAsync(Badge badge);
        Task<Badge> GetBadgeFromDatabaseAsync(int badgeId);
   
    }
}
