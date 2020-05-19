using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.GroupService
{
    public class ResultSheet
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<ExamResultAddDTO> ExamResultList { get; set; }
        public List<VerdictDTO> VerdictList { get; set; }
    }
}
