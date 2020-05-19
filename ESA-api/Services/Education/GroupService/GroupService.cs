using AutoMapper;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Mapping.DTO.EducationDTO.GroupsDTO;
using ESA_api.Mapping.DTO.EnrolmentDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using ESA_api.Models;
using ESA_api.Repositories.Education.CourseRepository;
using ESA_api.Repositories.Education.ExamResultRepository;
using ESA_api.Repositories.Education.GroupRepository;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;
using ESA_api.Repositories.Judge.VerdictRepository;
using ESA_api.Repositories.UserRepository.NormalUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repository;
        private readonly IAlgorithmTaskRepository _taskRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IExamResultRepository _resultRepository;
        private readonly IVerdictRepository _verdictRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository repository,
                            IAlgorithmTaskRepository taskRepository,
                            ICourseRepository courseRepository,
                            IUserRepository userRepository,
                            IExamResultRepository resultRepository,
                            IVerdictRepository verdictRepository,
                            IMapper mapper)
        {
            _repository = repository;
            _taskRepository = taskRepository;
            _courseRepository = courseRepository;
            _userRepository = userRepository;
            _resultRepository = resultRepository;
            _verdictRepository = verdictRepository;
            _mapper = mapper;
        }

        public async Task AddGroupAsync(GroupAddDTO groupAddDTO)
        {
            var group = _mapper.Map<Group>(groupAddDTO);
            await _repository.AddGroupAsync(group);
        }

        public async Task AssignCoursesToGroupAsync(CourseAssignmentAddDTO courseAssignmentAddDTO)
        {
            var assignment = _mapper.Map<CourseAssignment>(courseAssignmentAddDTO);
            await _repository.AssignCoursesToGroupAsync(assignment);
        }

        public async Task AssignManyCoursesToManyGroupAsync(CTGAssignmentDTO assignmentDTO)
        {
            CourseAssignmentAddDTO ctgAssignment = new CourseAssignmentAddDTO();
            foreach (var group in assignmentDTO.GroupIds)
            {
                foreach (var course in assignmentDTO.CourseIds)
                {
                    ctgAssignment.CourseId = course;
                    ctgAssignment.GroupId = group;
                    await AssignCoursesToGroupAsync(ctgAssignment);
                    ctgAssignment = new CourseAssignmentAddDTO();
                }
            }
        }

        public async Task AssignManyStudentsToManyGroupAsync(STGAssignmentDTO assignmentDTO)
        {
            GroupAssignmentAddDTO stgAssignment = new GroupAssignmentAddDTO();
            foreach (var group in assignmentDTO.GroupIds)
            {
                foreach (var student in assignmentDTO.StudentIds)
                {
                    stgAssignment.UserId = student;
                    stgAssignment.GroupId = group;
                    await AssignStudentsToGroupAsync(stgAssignment);
                    stgAssignment = new GroupAssignmentAddDTO();
                }
            }
        }

        public async Task AssignManyTasksToManyGroupAsync(TTGAssignmentDTO assignmentDTO)
        {
            TaskToGroupAssignmentAddDTO ttgAssignment = new TaskToGroupAssignmentAddDTO();
            foreach (var group in assignmentDTO.GroupIds)
            {
                foreach (var task in assignmentDTO.AlgorithmTaskIds)
                {
                    ttgAssignment.AlgorithmTaskId = task;
                    ttgAssignment.GroupId = group;
                    await AssignTasksToGroupAsync(ttgAssignment);
                    ttgAssignment = new TaskToGroupAssignmentAddDTO();
                }
            }
        }

        public async Task AssignStudentsToGroupAsync(GroupAssignmentAddDTO groupAssignmentAddDTO)
        {
            var assignment = _mapper.Map<GroupAssignment>(groupAssignmentAddDTO);
            await _repository.AssignStudentsToGroupAsync(assignment);
        }

        public async Task AssignTasksToGroupAsync(TaskToGroupAssignmentAddDTO taskToGroupAssignmentAddDTO)
        {
            var assignment = _mapper.Map<TaskToGroupAssignment>(taskToGroupAssignmentAddDTO);
            await _repository.AssignTasksToGroupAsync(assignment);
        }

        public async Task DeleteCoursesToGroupAssignmentAsync(int groupId, int courseId)
        {
            await _repository.DeleteCoursesToGroupAssignmentAsync(groupId, courseId);
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            await _repository.DeleteGroupAsync(groupId);
        }

        public async Task DeleteStudentsToGroupAssignmentAsync(int userId, int groupId)
        {
            await _repository.DeleteStudentsToGroupAssignmentAsync(userId, groupId);
        }

        public async Task DeleteTasksToGroupAssignmentAsync(int groupId, int taskId)
        {
            await _repository.DeleteTasksToGroupAssignmentAsync(groupId, taskId);
        }

        public async Task<List<CourseDTO>> GetCoursesAssignedToGroupAsync(int groupId)
        {
            List<Course> courses = new List<Course>();
            var group = await _repository.GetCoursesAssignedToGroupAsync(groupId);

            foreach (var assignment in group.CourseAssignment)
            {
                courses.Add(assignment.Course);
            }

            var mappedCourses = _mapper.Map<List<CourseDTO>>(courses);
            return mappedCourses;
        }

        public async Task<List<CourseEnlistedDTO>> GetCoursesAssignedToUserAsync(int userId)
        {
            int rateCounter = 0;
            int rateSum = 0;
            List<Course> courses = new List<Course>();
            List<Course> filteredCourses = new List<Course>();
            var user = await _repository.GetCoursesAssignedToUserAsync(userId);
            var results = await _resultRepository.GetExamResultsAsync(userId);

            foreach (var assignment in user.GroupAssignment)
            {
                foreach (var courseAssignment in assignment.Group.CourseAssignment)
                {
                    courses.Add(courseAssignment.Course);
                }
            }

            foreach (var course in courses.ToList())
            {
                
                if (!filteredCourses.Contains(course))
                {
                    filteredCourses.Add(course);
                }
            }
           
            var mappedCourses = _mapper.Map<List<CourseEnlistedDTO>>(filteredCourses);
            foreach (var item in mappedCourses)
            {
                var result = await _courseRepository.GetRateListByIdAsync(item.Id);
                rateCounter = 0;
                rateSum = 0;
                foreach (var rate in result)
                {
                    rateSum += rate.Points;
                    rateCounter++;
                }
                if (rateCounter > 0 && rateSum > 0)
                {
                    int rateAverage = rateSum / rateCounter;
                    item.Rate = rateAverage;
                }
            }

            return mappedCourses;
        }

        public async Task<List<UserDTO>> GetUsersAsync(int groupId)
        {
            List<User> usersAssignedToGroup = new List<User>();

            var group = await _repository.GetUsersAsync(groupId);
            foreach (var assignment in group.GroupAssignment)
            {
                usersAssignedToGroup.Add(assignment.User);
            }
            var mappedUsers = _mapper.Map<List<UserDTO>>(usersAssignedToGroup);
            return mappedUsers;
        }
        public async Task <List<ResultSheet>> GetExamResultsByStudentOfSpecificGroupAsync(int groupId)
        {
            List<ResultSheet> resultSheet = new List<ResultSheet>();
            ResultSheet sheet = new ResultSheet();

            var groupUsers = await GetUsersAsync(groupId); // użytkownicy z podanej grupy
           
            foreach (var user in groupUsers)
            {
                var studentResult = await _resultRepository.GetExamResultsAsync(user.Id);
                var mappedStudentResult = _mapper.Map<List<ExamResultAddDTO>>(studentResult);

                var studentVerdicts = await _verdictRepository.GetUserVerdictsAsync(user.Id);
                var mappedstudentVerdicts = _mapper.Map<List<VerdictDTO>>(studentVerdicts);

                sheet.Id = user.Id;
                sheet.Username = user.Username;
                sheet.Email = user.Email;
                sheet.ExamResultList = mappedStudentResult;
                sheet.VerdictList = mappedstudentVerdicts;
                resultSheet.Add(sheet);
                sheet = new ResultSheet();
            }
            return resultSheet;
        }

        public async Task<GroupDTO> GetGroupAsync(int groupId)
        {
            var group = await _repository.GetGroupAsync(groupId);
            return _mapper.Map<GroupDTO>(group);
        }

        public async Task<List<GroupDTO>> GetGroupsAsync()
        {
            var group = await _repository.GetGroupsAsync();
            return _mapper.Map<List<GroupDTO>>(group);
        }

        public async Task<List<GroupDTO>> GetGroupsCreatdByUserAsync(int teacherId)
        {
            var group = await _repository.GetGroupsCreatedByMeAsync(teacherId);
            return _mapper.Map<List<GroupDTO>>(group);
        }

        public async Task<List<AlgortihmTaskDTO>> GetTasksAssignedToGroupAsync(int groupId)
        {
            List<AlgorithmTask> tasks = new List<AlgorithmTask>();
            var group = await _repository.GetTasksAssignedToGroupAsync(groupId);

            foreach (var assignment in group.TaskToGroupAssignment)
            {
                tasks.Add(assignment.AlgorithmTask);
            }
            var mappedTasks = _mapper.Map<List<AlgortihmTaskDTO>>(tasks);
            return mappedTasks;
        }

        public async Task<List<AlgorithmTaskListForDisplayDTO>> GetTasksAssignedToUserAsync(int userId)
        {

            int rateCounter;
            int rateSum;
            List<AlgorithmTask> tasks = new List<AlgorithmTask>();
            List<AlgorithmTask> filteredTasks = new List<AlgorithmTask>();
            List<AlgorithmTask> correctTasks = new List<AlgorithmTask>();
            var user = await _repository.GetTasksAssignedToUserAsync(userId);
            var verdicts = await _verdictRepository.GetUserVerdictsAsync(userId);

            foreach (var assignment in user.GroupAssignment)
            {
                foreach (var courseAssignment in assignment.Group.TaskToGroupAssignment)
                {
                    tasks.Add(courseAssignment.AlgorithmTask);
                }
            }
            foreach (var task in tasks.ToList())
            {
                if (!filteredTasks.Contains(task))
                {
                    filteredTasks.Add(task);
                }
            }

            foreach (var task in filteredTasks)
            {
                var taskDB = await _repository.GetAlgorithmTaskAsync(task.Id);
                correctTasks.Add(taskDB);
            }

            var mappedTasks = _mapper.Map<List<AlgorithmTaskListForDisplayDTO>>(correctTasks);
            foreach (var item in mappedTasks)
            {
                var result = await _taskRepository.GetRateListByIdAsync(item.Id);
                rateCounter = 0;
                rateSum = 0;
                foreach (var rate in result)
                {
                    rateSum += rate.Points;
                    rateCounter++;
                }
                if (rateCounter > 0 && rateSum > 0)
                {
                    int rateAverage = rateSum / rateCounter;
                    item.RatePoints = rateAverage;
                }
            }
            foreach (var item in mappedTasks.ToList())
            {
                foreach (var verdict in verdicts)
                {
                    if (verdict.AlgorithmTaskId == item.Id)
                    {
                        mappedTasks.Remove(item);
                        break;
                    }
                }
            }
            return mappedTasks;
        }

        public Task UpdateGroupAsync(GroupDTO groupDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Solution>> GetVerdictByTaskOfSpecificGroupAsync(int groupId, int taskId)
        {
            List<Solution> solutions = new List<Solution>();
            Solution solution = new Solution();

            var group = await _repository.GetGroupVerdictByTask(groupId);
            foreach (var assignment in group.GroupAssignment)
            {
                foreach (var verdict in assignment.User.Verdict)
                {
                    if (verdict.AlgorithmTaskId == taskId)
                    {
                        solution.VerdictName = verdict.VerdictName;
                        solution.StudentName = assignment.User.Username;
                        solution.AlgorithmTaskId = verdict.AlgorithmTaskId;
                        solution.IsCopied = verdict.IsCopied;
                        solution.VerdictId = verdict.Id;
                        solutions.Add(solution);
                        solution = new Solution();
                    }
                }
            }

            return solutions;
        }
    }
}
