﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.EducationDTO.CoursesDTO
{
    public class CourseAddDTO
    {
        public string CourseName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string CourseIconUrl { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
