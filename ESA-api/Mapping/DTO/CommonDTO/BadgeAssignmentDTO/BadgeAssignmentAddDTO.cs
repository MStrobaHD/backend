﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping.DTO.CommonDTO.BadgeAssignmentDTO
{
    public class BadgeAssignmentAddDTO
    {
        public DateTime AssignmentDate { get; set; }
        public int BadgeId { get; set; }
        public int UserId { get; set; }
    }
}
