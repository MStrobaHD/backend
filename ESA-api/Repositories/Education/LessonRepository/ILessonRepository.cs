using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.LessonRepository
{
    public interface ILessonRepository
    {
        Task<List<Lesson>> GetLessonsAsync();
        Task<Lesson> GetLessonAsync(int lessonId);
        Task<List<Lesson>> GetCourseLessonsAsync(int courseId);
        Task AddLessonAsync(Lesson lesson);
        Task AddServerAssetAsync(ServerAsset asset);
        Task AddCloudAssetAsync(CloudAsset asset);
        Task UpdateLessonAsync(Lesson lesson);
        Task DeleteLessonAsync(int lessonId);
        Task<bool> FindLessonAsync(int lessonId);
        Task<bool> LessonExistsAsync(int lessonId);
        Task<Lesson> GetLessonFromDatabaseAsync(int lessonId);
    }
}
