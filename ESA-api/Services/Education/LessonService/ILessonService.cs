using ESA_api.Mapping.DTO.EducationDTO.LessonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.LessonService
{
   public interface ILessonService
    {
        Task<List<LessonListDTO>> GetLessonsAsync();
        Task<LessonDTO> GetLessonAsync(int lessonId);
        Task<List<LessonListDTO>> GetCourseLessonsAsync(int courseId);
        Task<int> AddLessonAsync(LessonAddDTO lessonAddDTO);
        Task<int> AddServerAssetAsync(ServerAssetAddDTO serverAssetAddDTO);
        Task<int> AddCloudAssetAsync(CloudAssetAddDTO cloudAssetAddDTO);
        Task<int> UpdateLessonAsync(int lessonId, LessonAddDTO lessonAddDTO);
        Task DeleteLessonAsync(int lessonId);
        Task<bool> FindLessonAsync(int lessonId);
    }
}
