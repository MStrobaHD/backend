using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.ExamResultRepository;

namespace ESA_api.Services.Education.ExamResultService
{
    public class ExamResultService : IExamResultService
    {
        private readonly IExamResultRepository _repository;
        private readonly IMapper _mapper;

        public ExamResultService(IExamResultRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddExamResultAsync(ExamResultAddDTO examResultAddDTO)
        {
            var examResult = _mapper.Map<ExamResult>(examResultAddDTO);
            await _repository.AddResultAsync(examResult);
            return examResult.Id;
        }

    }
}
