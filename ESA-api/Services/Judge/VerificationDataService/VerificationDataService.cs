using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Model;
using ESA_api.Repositories.Judge.VerificationDataRepository;

namespace ESA_api.Services.Judge.VerificationDataService
{
    public class VerificationDataService : IVerificationDataService
    {
        private readonly IVerificationDataRepository _repository;
        private readonly IMapper _mapper;

        public VerificationDataService(IVerificationDataRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddVerificationDataAsync(VerificationDataAddDTO verificationDataAddDTO)
        {
            var verificationData = _mapper.Map<VerificationData>(verificationDataAddDTO);
            await _repository.AddVerificationDataAsync(verificationData);
            return verificationData.Id;
        }
    }
}
