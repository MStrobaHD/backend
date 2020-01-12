using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Model;
using ESA_api.Repositories.Judge.VerdictRepository;

namespace ESA_api.Services.Judge.VerdictService
{
    public class VerdictService : IVerdictService
    {
        private readonly IVerdictRepository _repository;
        private readonly IMapper _mapper;

        public VerdictService(IVerdictRepository repository, IMapper mapper)
        {
           _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddVerdictAsync(VerdictAddDTO verdictAddDTO)
        {
            var verdict = _mapper.Map<Verdict>(verdictAddDTO);
            await _repository.AddVerdictAsync(verdict);
            return verdict.Id;
        }

        public async Task<List<VerdictDTO>> GetUserVerdictsAsync(int userId)
        {
            var verdicts = await _repository.GetUserVerdictsAsync(userId);
            return _mapper.Map<List<VerdictDTO>>(verdicts);
        }
    }
}
