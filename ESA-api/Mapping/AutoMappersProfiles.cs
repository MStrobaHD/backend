﻿using AutoMapper;
using ESA_api.Mapping.DTO;
using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using ESA_api.Mapping.DTO.CommonDTO.ExperienceDTO;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using ESA_api.Mapping.DTO.EducationDTO.FlashcardsDTO;
using ESA_api.Mapping.DTO.EducationDTO.FlashcardSetsDTO;
using ESA_api.Mapping.DTO.EducationDTO.GroupsDTO;
using ESA_api.Mapping.DTO.EducationDTO.LessonsDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using ESA_api.Mapping.DTO.EnrolmentDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmCategorysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.JudgeDTO.ComplexitysDTO;
using ESA_api.Mapping.DTO.JudgeDTO.LevelsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using ESA_api.Models;
using ESA_api.Services.Judge.CodeAnalyzeService.CodeAnalyzeModels;
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
            CreateMap<AlgorithmTaskAddDTO, AlgorithmTask>().ReverseMap();
            CreateMap<AlgorithmCategoryListDTO, AlgorithmCategory>().ReverseMap();
            // Verdict  mapping
            CreateMap<VerdictAddDTO, Verdict>().ReverseMap();
            // Level mapping
            CreateMap<LevelDTO, Level>().ReverseMap();
            CreateMap<LevelAddDTO, Level>().ReverseMap();
            CreateMap<LevelListDTO, Level>().ReverseMap();
            // VerificationData mapping
            CreateMap<VerificationDataDTO, VerificationData>().ReverseMap();
            CreateMap<VerificationDataAddDTO, VerificationData>().ReverseMap();
            // Course mapping
            CreateMap<CourseAddDTO, Course>();
            CreateMap<CourseListDTO, Course>().ReverseMap();
            CreateMap<EnlistParametersDTO, CourseEnrolment>().ReverseMap();
            // Course mapping
            CreateMap<QuestionListDTO, Question>().ReverseMap();
            CreateMap<MultiSelectQuestionListDTO, MultiSelectQuestion>().ReverseMap();

            CreateMap<UserEnlistedDTO, User>().ReverseMap();
            CreateMap<CourseEnrolmentEnlistedDTO, CourseEnrolment>().ReverseMap();
            CreateMap<CourseEnlistedDTO, Course>().ReverseMap();
            CreateMap<CourseRatingDTO, CourseRating>().ReverseMap();
            CreateMap<RatingDTO, Rating>().ReverseMap();

            // Exam mapping
            CreateMap<ExamDTO, Exam>().ReverseMap();
            CreateMap<ExamListDTO, Exam>().ReverseMap();
            CreateMap<ExamResultAddDTO, ExamResult>().ReverseMap();

            CreateMap<CategoryDTO, Category>().ReverseMap();
            // AlgorithmTask mapping
            CreateMap<AlgorithmTaskListForDisplayDTO, AlgorithmTask>().ReverseMap();
            CreateMap<AlgorithmTaskForSolveDTO, AlgorithmTask>().ReverseMap();
            // Lesson mapping
            CreateMap<LessonAddDTO, Lesson>().ReverseMap();
            CreateMap<LessonListDTO, Lesson>().ReverseMap();
            CreateMap<ServerAssetAddDTO, ServerAsset>().ReverseMap();
            CreateMap<CloudAssetAddDTO, CloudAsset>().ReverseMap();
            // Flashcard
            CreateMap<FlashcardAddDTO, Flashcard>().ReverseMap();
            CreateMap<FlashcardDTO, Flashcard>().ReverseMap();
            CreateMap<FlashcardSetForFlashcardDTO, FlashcardSet>().ReverseMap();
            CreateMap<FlashcardSetAddDTO, FlashcardSet>().ReverseMap();
            CreateMap<FlashcardSetDTO, FlashcardSet>().ReverseMap();
            CreateMap<FlashcardSetListDTO, FlashcardSet>().ReverseMap();
            // Exam mapping
            CreateMap<ExamAddDTO, Exam>();
            // Question mapping
            CreateMap<QuestionAddDTO, Question>();
            // MultiSelectQuestion mapping
            CreateMap<MultiSelectQuestionAddDTO, MultiSelectQuestion>();
            // OrderedBlock mapping
            CreateMap<OrderedBlockAddDTO, OrderedBlock>();
            CreateMap<OrderedBlockListDTO, OrderedBlock>().ReverseMap();
            // Verdict DTO
            CreateMap<VerdictDTO, Verdict>().ReverseMap();
            CreateMap<VerdictWithMetrics, Verdict>().ReverseMap();
            CreateMap<MetricsAddDTO, Metrics>().ReverseMap();
            CreateMap<ExperienceAddDTO, Experience>().ReverseMap();
            CreateMap<BadgeAddDTO, Badge>().ReverseMap();
            CreateMap<BadgeDTO, Badge>().ReverseMap();
            CreateMap<Metrics, MetricsSheet>().ReverseMap();

            // Group
            CreateMap<CourseAssignmentAddDTO, CourseAssignment>().ReverseMap();
            CreateMap<GroupAssignmentAddDTO, GroupAssignment>().ReverseMap();
            CreateMap<TaskToGroupAssignmentAddDTO, TaskToGroupAssignment>().ReverseMap();
            CreateMap<CourseAssignmentAddDTO, CourseAssignment>().ReverseMap();
            CreateMap<GroupAssignmentAddDTO, GroupAssignment>().ReverseMap();
            CreateMap<TaskToGroupAssignmentAddDTO, TaskToGroupAssignment>().ReverseMap();
            CreateMap<GroupDTO, Group>().ReverseMap();
            CreateMap<GroupAddDTO, Group>().ReverseMap();
            CreateMap<CopiedSolutionDTO, CopiedSolution>().ReverseMap();

        }
    }
}
