using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO
{
    public class OrderedBlockAddDTO
    {
        public string Content { get; set; }
        public int BlockPosition { get; set; }
        public int ExamId { get; set; }
    }
}
