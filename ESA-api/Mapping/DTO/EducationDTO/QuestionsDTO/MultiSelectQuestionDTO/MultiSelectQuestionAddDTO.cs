using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO
{
    public class MultiSelectQuestionAddDTO
    {
        public int ExamId { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string OptionOne { get; set; }
        public string OptionTwo { get; set; }
        public string OptionThree { get; set; }
        public string OptionFour { get; set; }
        public string Hint { get; set; }
    }
}
