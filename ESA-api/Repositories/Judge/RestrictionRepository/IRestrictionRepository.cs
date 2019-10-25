﻿using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Judge.RestrictionRepository
{
    public interface IRestrictionRepository
    {
        Task<List<Restriction>> GetRestrictionsAsync();
        Task<Restriction> GetRestrictionAsync(int restrictionId);
        Task AddRestrictionAsync(Restriction restriction);
        Task UpdateRestrictionAsync(Restriction restriction);
        Task DeleteRestrictionAsync(int restrictionId);
        Task<bool> FindRestrictionAsync(int restrictionId);
        Task<bool> RestrictionExistsAsync(int restrictionId);
        Task<Restriction> GetRestrictionFromDatabaseAsync(int restrictionId);
    }
}
