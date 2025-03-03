﻿using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmCategorysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.ComplexitysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.LevelsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO
{
    public class AlgorithmTaskListForDisplayDTO
    {
        public int Id { get; set; }
        public string AlgorithmTaskName { get; set; }
        public string Description { get; set; }
        public decimal TimeLimit { get; set; }
        public int? MemoryLimit { get; set; }
        public int? ElementaryOperationLimit { get; set; }
        public int? LinesOfCodeLimit { get; set; }
        public int? TimeToSolveLimit { get; set; }
        public int? ComplexityOrder { get; set; }
        public int LevelId { get; set; }
        public int AlgorithmCategoryId { get; set; }
        public int ComplexityId { get; set; }
        public int RatePoints { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public ComplexityDTO Complexity { get; set; }
        public AlgorithmCategoryDTO AlgorithmCategory { get; set; }
        public LevelDTO Level { get; set; }
    }
}
