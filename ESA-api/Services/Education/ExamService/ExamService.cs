using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.ExamRepository;
using ESA_api.Repositories.Education.ExamResultRepository;

namespace ESA_api.Services.Education.ExamService
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExamResultRepository _examResultRepository;

        public ExamService(IExamRepository repository, IMapper mapper, IExamResultRepository examResultRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _examResultRepository = examResultRepository;
        }

        public async Task<int> AddExamAsync(ExamAddDTO examAddDTO)
        {
            var exam = _mapper.Map<Exam>(examAddDTO);
            await _repository.AddExamAsync(exam);
            return exam.Id;
        }

        public async Task DeleteExamAsync(int examId)
        {
            await _repository.DeleteExamAsync(examId);
        }

        public async Task<bool> FindExamAsync(int examId)
        {
            if (await _repository.FindExamAsync(examId))
                return true;
            return false;
        }

        public async Task<List<ExamListDTO>> GetAvailableExamsAsync(int courseId, int userId)
        {
            var exams = await _repository.GetCourseExamsAsync(courseId);
            var results = await _examResultRepository.GetExamResultsAsync(userId);
            foreach (var item in exams.ToList())
            {
                foreach (var result in results)
                {
                    if (item.Id == result.ExamId)
                    {
                        exams.Remove(item);
                        break;
                    }
                }
            }
            return _mapper.Map<List<ExamListDTO>>(exams);
        }

        public async Task<List<ExamListDTO>> GetCourseExamsAsync(int courseId)
        {
            var exams = await _repository.GetCourseExamsAsync(courseId);
           
            return _mapper.Map<List<ExamListDTO>>(exams);
        }

        public async Task<ExamDTO> GetExamAsync(int id)
        {
            var exam = await _repository.GetExamAsync(id);
            return _mapper.Map<ExamDTO>(exam);
        }

        public async Task<List<ExamListDTO>> GetExamsAsync()
        {
            var exams = await _repository.GetExamsAsync();
            return _mapper.Map<List<ExamListDTO>>(exams);
        }

        public async Task<int> UpdateExamAsync(int examId, ExamAddDTO examAddDTO)
        {
            var examFromDatabase = await _repository.GetExamFromDatabaseAsync(examId);
            var examToDatabase = _mapper.Map(examAddDTO, examFromDatabase);

            await _repository.UpdateExamAsync(examToDatabase);
            return examToDatabase.Id;
        }
    }
}
