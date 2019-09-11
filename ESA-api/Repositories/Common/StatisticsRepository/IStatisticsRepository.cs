using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<int> CountRegisteredUsersAsync();
        Task<int> CountRegisteredTeachersAsync();
        Task<int> CountAvailableCoursesAsync();
        Task<int> CountPositiveExamsAsync();
        Task<int> CountNegativeExamsAsync();
        Task<int> CountExamsAsync();
        Task<int> CountAlgorithmsTaskAsync();
        Task<int> CountSolvedAlgorithmsAsync();
        
    }
}
