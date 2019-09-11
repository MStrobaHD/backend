using AutoMapper;
using ESA_api.Mapping.DTO;
using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Mapping
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            // User mapping
            CreateMap<UserRegisterDTO, User>();
            // Course mapping
            CreateMap<CourseAddDTO, Course>();
            CreateMap<CourseListDTO, Course>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
