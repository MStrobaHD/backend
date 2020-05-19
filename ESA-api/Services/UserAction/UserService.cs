using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.CommonDTO.BadgeAssignmentDTO;
using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Mapping.DTO.CommonDTO.ExperienceDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.ExamResultRepository;
using ESA_api.Repositories.UserRepository.NormalUser;

namespace ESA_api.Services.UserAction
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IExamResultRepository _resultRepository;
        public static int badgeAssignedId;

        public UserService(IUserRepository repository, IMapper mapper, IExamResultRepository resultRepository)
        {
            _repository = repository;
            _mapper = mapper;
           _resultRepository = resultRepository;
        }

        public async Task AddBadgeAsync(BadgeAddDTO badgeAddDTO)
        {
            var badge = _mapper.Map<Badge>(badgeAddDTO);
            await _repository.AddBadgeAsync(badge);
        }

        public async Task<int> AddOrUpdateExperienceAsync(ExperienceAddDTO experienceAddDTO)
        {
            bool isBadgeAssigned = false;
            
            int experiencePoints;
            var mappedExperience = _mapper.Map<Experience>(experienceAddDTO);
            var experienceExist = await _repository.FindExperienceAsync(experienceAddDTO.UserId, experienceAddDTO.CategoryId);

            if (experienceExist)
            {
                var experienceFromDB = await _repository.GetExperienceAsync(experienceAddDTO.UserId, experienceAddDTO.CategoryId);
                experienceFromDB.ExperiencePoints += experienceAddDTO.ExperiencePoints;
                experiencePoints = experienceFromDB.ExperiencePoints;
                await _repository.UpdateExperienceAsync(experienceFromDB);
            }
            else
            {
                await _repository.AddExperienceAsync(mappedExperience);
                experiencePoints = mappedExperience.ExperiencePoints;
            }
            

            var badges = await _repository.GetAllBadgesAsync();
            var assignedBadges = await GetUserAssignedBadgesAsync(mappedExperience.UserId);
            var mappedBadges = _mapper.Map<List<Badge>>(assignedBadges);

            foreach (var badge in badges)
            {
                if (experiencePoints >= badge.ExperiencePoints && badge.BadgeAssignment.Count == 0)
                {
                    isBadgeAssigned = true;
                    badgeAssignedId = badge.Id;
                    BadgeAssignment assignment = new BadgeAssignment();
                    assignment.UserId = mappedExperience.UserId;
                    assignment.BadgeId = badge.Id;
                    assignment.AssignmentDate = DateTime.Now;
                    await _repository.AssignBadgeAsync(assignment);
                }
            }
            if (isBadgeAssigned == true)
            {
                return badgeAssignedId;
            }
            return 999;
        }

        public async Task AssignBadgeAsync(BadgeAssignmentAddDTO badgeAssignmentAddDTO)
        {
            var badgeAssignment = _mapper.Map<BadgeAssignment>(badgeAssignmentAddDTO);
            await _repository.AssignBadgeAsync(badgeAssignment);
        }

        public async Task<List<BadgeDTO>> GetAllBadgesAsync()
        {
            var badges = await _repository.GetAllBadgesAsync();
            return _mapper.Map<List<BadgeDTO>>(badges);
        }

        public Task<int> GetExperiencePoints()
        {
            throw new NotImplementedException();
        }

        public async Task<List<BadgeDTO>> GetUserAssignedBadgesAsync(int userId)
        {
            List<Badge> badges = new List<Badge>();
            var userBadges = await _repository.GetUserAssignedBadges(userId);

            foreach (var assignment in userBadges.BadgeAssignment)
            {
                badges.Add(assignment.Badge);
            }
            var mappedBadges = _mapper.Map<List<BadgeDTO>>(badges);
            return mappedBadges;
        }

        public async Task<UserDTO> GetUserDataAsync(int userId)
        {
            var userData = await _repository.GetUserDataAsync(userId);
            return _mapper.Map<UserDTO>(userData);
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _repository.GetUsersAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<int> UpdateUserAsync(int id, UserDTO userDTO)
        {
            var previousUser = await _repository.GetUserFromBaseAsync(id);
            userDTO.Id = id;

            var userInfo =  _mapper.Map(userDTO, previousUser);

            await _repository.UpdateUserDataAsync(userInfo);
            return userInfo.Id;
        }

        public async Task<int> UpdateUserGroupRoleAsync(List<User> users)
        {
            foreach (var user in users)
            {
                var userPrevious = await _repository.GetUserFromBaseAsync(user.Id);
                userPrevious.Role = user.Role;

                await _repository.UpdateUserRoleAsync(userPrevious);
            }
            return 2;
        }

        public async Task<int> UpdateUserRoleAsync(User user)
        {
            var userPrevious = await _repository.GetUserFromBaseAsync(user.Id);
            userPrevious.Role = user.Role;

            await _repository.UpdateUserRoleAsync(userPrevious);

            return user.Id;
        }

        public async Task<UserStatistics> GetUserStatisticsAsync()
        {
            int administrators = 0;
            int students = 0;
            int nauczyciel = 0;
            UserStatistics userStats = new UserStatistics();

            var users = await _repository.GetUsersAsync();
            foreach (var user in users)
            {
                if (user.Role == "Administrator")
                {
                    administrators++;
                }
                else if (user.Role == "Nauczyciel")
                {
                    nauczyciel++;
                } else
                {
                    students++;
                }
            }
            userStats.AdministratorsNumber = administrators;
            userStats.TeachersNumber = nauczyciel;
            userStats.StudentsNumber = students;
            return userStats;
        }

        public async Task<MarksStatistics> GetUserMarkStatisticsAsync(int userId)
        {
            int negative = 0;
            int positive = 0;

            MarksStatistics marks = new MarksStatistics();

            var userMarks = await _resultRepository.GetExamResultsAsync(userId);
            foreach (var mark in userMarks)
            {
                if (mark.Mark == "Bardzo dobry" || mark.Mark == "Dobry" || mark.Mark == "Dostateczny")
                {
                    positive++;
                } else
                {
                    negative++;
                }
            }
            marks.positiveMarksNumber = positive;
            marks.negativeMarksNumber = negative;

            return marks;
        }

        public async Task<MarksStatistics> GetAllMarkStatisticsAsync()
        {
            int negative = 0;
            int positive = 0;

            MarksStatistics marks = new MarksStatistics();

            var userMarks = await _resultRepository.GetExamResultAllAsync();
            foreach (var mark in userMarks)
            {
                if (mark.Mark == "Bardzo dobry" || mark.Mark == "Dobry" || mark.Mark == "Dostateczny")
                {
                    positive++;
                }
                else
                {
                    negative++;
                }
            }
            marks.positiveMarksNumber = positive;
            marks.negativeMarksNumber = negative;

            return marks;
        }

        public async Task<VerdictsStatistics> GetUserVerdictsStatisticsAsync(int userId)
        {
            int ac = 0;
            int nac = 0;
            int tle = 0;
            int mle = 0;
            int re = 0;
            int ce = 0;
            int loce = 0;

            VerdictsStatistics verdictsStatistics = new VerdictsStatistics();
            var stats = await _repository.GetUserVerdictAsync(userId);

            foreach (var item in stats.Verdict)
            {
                if (item.VerdictName == "Accepted")
                {
                    ac++;
                } else if (item.VerdictName == "NotAccepted")
                {
                    nac++;
                } else if (item.VerdictName == "CompilationError")
                {
                    ce++;
                } else if (item.VerdictName == "RuntimeError")
                {
                    re++;
                } else if (item.VerdictName == "TimeLimitExceeded")
                {
                    tle++;
                }
                else if (item.VerdictName == "MemoryLimitExceeded")
                {
                    mle++;
                } else
                {
                    loce++;
                }
            }
            verdictsStatistics.AcceptedNumber = ac;
            verdictsStatistics.NotAcceptedNumber = nac;
            verdictsStatistics.TimeLimitExceededNumber = tle;
            verdictsStatistics.MemoryLimitExceededNumber = mle;
            verdictsStatistics.CompilationErrorNumber = ce;
            verdictsStatistics.RuntimeErrorNumber = re;
            verdictsStatistics.LinesOfCodeLimitExceededNumber = loce;
            return verdictsStatistics;
        }

        public async Task<VerdictsStatistics> GetAllVerdictsStatisticsAsync()
        {
            int ac = 0;
            int nac = 0;
            int tle = 0;
            int mle = 0;
            int re = 0;
            int ce = 0;
            int loce = 0;

            VerdictsStatistics verdictsStatistics = new VerdictsStatistics();
            var stats = await _repository.GetAllVerdictAsync();

            foreach (var item in stats)
            {
                if (item.VerdictName == "Accepted")
                {
                    ac++;
                }
                else if (item.VerdictName == "NotAccepted")
                {
                    nac++;
                }
                else if (item.VerdictName == "CompilationError")
                {
                    ce++;
                }
                else if (item.VerdictName == "RuntimeError")
                {
                    re++;
                }
                else if (item.VerdictName == "TimeLimitExceeded")
                {
                    tle++;
                }
                else if (item.VerdictName == "MemoryLimitExceeded")
                {
                    mle++;
                }
                else
                {
                    loce++;
                }
            }
            verdictsStatistics.AcceptedNumber = ac;
            verdictsStatistics.NotAcceptedNumber = nac;
            verdictsStatistics.TimeLimitExceededNumber = tle;
            verdictsStatistics.MemoryLimitExceededNumber = mle;
            verdictsStatistics.CompilationErrorNumber = ce;
            verdictsStatistics.RuntimeErrorNumber = re;
            verdictsStatistics.LinesOfCodeLimitExceededNumber = loce;
            return verdictsStatistics;
        }

        public async Task<AssetsStatistics> GetAssetsStatisticsAsync()
        {
            AssetsStatistics assetsStatistics = new AssetsStatistics();
            assetsStatistics.AlgorithmTasksNumber = await _repository.CountAlgorithmsAsync();
            assetsStatistics.CoursesNumber = await _repository.CountCoursesAsync();
            assetsStatistics.ExamsNumber = await _repository.CountExamsAsync();
            assetsStatistics.LessonNumber = await _repository.CountLessonsAsync();
            assetsStatistics.FlashcardsSetNumber = await _repository.CountFlashcardSetsAsync();

            return assetsStatistics;
        }
    }
}
