using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.LessonsDTO;
using ESA_api.Model;
using ESA_api.Repositories.Education.LessonRepository;

namespace ESA_api.Services.Education.LessonService
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _repository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository repository,
                             IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddCloudAssetAsync(CloudAssetAddDTO cloudAssetAddDTO)
        {
            var asset = _mapper.Map<CloudAsset>(cloudAssetAddDTO);
            await _repository.AddCloudAssetAsync(asset);
            return asset.Id;
        }

        public async Task<int> AddLessonAsync(LessonAddDTO lessonAddDTO)
        {
            var lesson = _mapper.Map<Lesson>(lessonAddDTO);
            await _repository.AddLessonAsync(lesson);
            return lesson.Id;
        }

        public async Task<int> AddServerAssetAsync(ServerAssetAddDTO serverAssetAddDTO)
        {
            var asset = _mapper.Map<ServerAsset>(serverAssetAddDTO);
            await _repository.AddServerAssetAsync(asset);
            return asset.Id;
        }

        public async Task DeleteLessonAsync(int lessonId)
        {
            await _repository.DeleteLessonAsync(lessonId);
        }

        public async Task<bool> FindLessonAsync(int lessonId)
        {
            if (await _repository.FindLessonAsync(lessonId))
                return true;
            return false;
        }

        public async Task<List<LessonListDTO>> GetCourseLessonsAsync(int courseId)
        {
            var lessons = await _repository.GetCourseLessonsAsync(courseId);
            return _mapper.Map<List<LessonListDTO>>(lessons);
        }

        public Task<LessonDTO> GetLessonAsync(int lessonId)
        {
            throw new NotImplementedException();
        }

        public Task<List<LessonListDTO>> GetLessonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateLessonAsync(int lessonId, LessonAddDTO lessonAddDTO)
        {
            throw new NotImplementedException();
        }
    }
}
