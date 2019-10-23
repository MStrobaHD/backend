﻿using AutoMapper;
using ESA_api.Mapping.DTO;
using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using ESA_api.Mapping.DTO.EducationDTO.LessonsDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmCategorysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.JudgeDTO.ComplexitysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.LevelsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
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
            CreateMap<UserDTO, User>().ReverseMap();
            // Complexity mapping
            CreateMap<ComplexityDTO, Complexity>().ReverseMap();
            CreateMap<ComplexityListDTO, Complexity>().ReverseMap();
            // AlgorithmCategory mapping
            CreateMap<AlgorithmCategoryDTO, AlgorithmCategory>().ReverseMap();
            CreateMap<AlgorithmCategoryListDTO, AlgorithmCategory>().ReverseMap();
            // Level mapping
            CreateMap<LevelDTO, Level>().ReverseMap();
            CreateMap<LevelAddDTO, Level>().ReverseMap();
            CreateMap<LevelListDTO, Level>().ReverseMap();
            // VerificationData mapping
            CreateMap<VerificationDataDTO, VerificationData>().ReverseMap();
            // Course mapping
            CreateMap<CourseAddDTO, Course>();
            CreateMap<CourseListDTO, Course>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            // AlgorithmTask mapping
            CreateMap<AlgorithmTaskListForDisplayDTO, AlgorithmTask>().ReverseMap();
            // Lesson mapping
            CreateMap<LessonAddDTO, Lesson>();
            CreateMap<ServerAssetAddDTO, ServerAsset>();
            CreateMap<CloudAssetAddDTO, CloudAsset>();
            // Exam mapping
            CreateMap<ExamAddDTO, Exam>();
            // Question mapping
            CreateMap<QuestionAddDTO, Question>();
            // MultiSelectQuestion mapping
            CreateMap<MultiSelectQuestionAddDTO, MultiSelectQuestion>();
            // OrderedBlock mapping
            CreateMap<OrderedBlockAddDTO, OrderedBlock>();
        }
    }
}
