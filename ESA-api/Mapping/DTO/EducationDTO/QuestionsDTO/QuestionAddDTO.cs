using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.QuestionDTO
{
    public class QuestionAddDTO
    {
        public string QuestionContent { get; set; }
        public string Answer { get; set; }
        public int ExamId { get; set; }
    }
}
