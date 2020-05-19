using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Mapping.DTO.CommonDTO.ExperienceDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.ExamResultRepository;
using ESA_api.Repositories.UserRepository.NormalUser;
using ESA_api.Services.UserAction;

namespace ESA_api.Services.Education.ExamResultService
{
    public class ExamResultService : IExamResultService
    {
        private readonly IExamResultRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ExamResultService(IExamResultRepository repository,
            IUserRepository userRepository,
            IMapper mapper,
            IUserService userService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<BadgeDTO> AddExamResultAsync(ExamResultAddDTO examResultAddDTO)
        {
            // pobranie danych do zaaktualizowanie pkt doświadczenia
            int categoryId = await _userRepository.GetCategoryId(examResultAddDTO.ExamId);
            int userId = examResultAddDTO.UserId;
            Badge badge = new Badge();
            // dodanie doświadczenia
           var badgeId =  await _userService.AddOrUpdateExperienceAsync(new ExperienceAddDTO(examResultAddDTO.Points, categoryId, userId ));
            
            if (badgeId != 999)
            {
                badge = await _userRepository.GetBadgeAsync(badgeId);
                var badgeMapped = _mapper.Map<BadgeDTO>(badge);
                return badgeMapped;
            }

            var examResult = _mapper.Map<ExamResult>(examResultAddDTO);
            await _repository.AddResultAsync(examResult);
            return null;
        }

        public async Task<List<ExamResultAddDTO>> GetExamResultsAsync(int userId)
        {
            var results = await _repository.GetExamResultsAsync(userId);
            return _mapper.Map<List<ExamResultAddDTO>>(results);
        }
    }
}
