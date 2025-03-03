﻿using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.VerdictService
{
    public interface IVerdictService
    {
        Task<int> AddVerdictAsync(VerdictAddDTO verdictAddDTO);
        Task<int> AddMetricsAsync(Metrics metrics);
        Task<List<VerdictDTO>> GetUserVerdictsAsync(int userId);
        Task<VerdictDTO> GetVerdictAsync(int verdictId);
        Task<VerdictWithMetrics> GetVerdictWithMetricsAsync(int verdictId);
        Task UpdateVerdictAsync(int verdictId, string verdictName);
    }
}
