using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Models;
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

        public async Task<int> AddMetricsAsync(Metrics metrics)
        {
            //var metrics = _mapper.Map<Metrics>(metricsAddDTO);
            await _repository.AddMetricsAsync(metrics);
            return metrics.Id;
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

        public async Task<VerdictDTO> GetVerdictAsync(int verdictId)
        {
            var verdicts = await _repository.GetVerdictAsync(verdictId);
            return _mapper.Map<VerdictDTO>(verdicts);
        }

        public async Task<VerdictWithMetrics> GetVerdictWithMetricsAsync(int verdictId)
        {
            var verdicts = await _repository.GetVerdictWithMetricsAsync(verdictId);
            return _mapper.Map<VerdictWithMetrics>(verdicts);
        }

        public async Task UpdateVerdictAsync(int verdictId, string verdictName)
        {
            var verdictFromDB = await _repository.GetVerdictAsync(verdictId);
            verdictFromDB.VerdictName = verdictName;
            await _repository.UpdateVerdictAsync(verdictFromDB);
        }
    }
}
