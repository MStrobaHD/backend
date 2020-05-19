using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Mapping.DTO.EducationDTO.GroupsDTO;
using ESA_api.Mapping.DTO.EnrolmentDTO;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.UserProfileDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Education.GroupService
{
    public interface IGroupService
    {
        Task AddGroupAsync(GroupAddDTO groupAddDTO);
        Task AssignCoursesToGroupAsync(CourseAssignmentAddDTO courseAssignmentAddDTO);
        Task AssignTasksToGroupAsync(TaskToGroupAssignmentAddDTO taskToGroupAssignmentAddDTO);
        Task AssignStudentsToGroupAsync(GroupAssignmentAddDTO groupAssignmentAddDTO);
        Task AssignManyStudentsToManyGroupAsync(STGAssignmentDTO assignmentDTO);
        Task AssignManyTasksToManyGroupAsync(TTGAssignmentDTO assignmentDTO);
        Task AssignManyCoursesToManyGroupAsync(CTGAssignmentDTO assignmentDTO);
        Task DeleteCoursesToGroupAssignmentAsync(int groupId, int courseId);
        Task DeleteTasksToGroupAssignmentAsync(int groupId, int taskId);
        Task DeleteStudentsToGroupAssignmentAsync(int userId, int groupId);
        Task UpdateGroupAsync(GroupDTO groupDTO);
        Task DeleteGroupAsync(int groupId);
        Task<List<GroupDTO>> GetGroupsAsync();
        Task<GroupDTO> GetGroupAsync(int groupId);
        Task<List<CourseDTO>> GetCoursesAssignedToGroupAsync(int groupId);
        Task<List<AlgortihmTaskDTO>> GetTasksAssignedToGroupAsync(int groupId);
        Task<List<AlgorithmTaskListForDisplayDTO>> GetTasksAssignedToUserAsync(int userId);
        Task<List<CourseEnlistedDTO>> GetCoursesAssignedToUserAsync(int userId);
        Task <List<ResultSheet>> GetExamResultsByStudentOfSpecificGroupAsync(int groupId);
        Task<List<Solution>> GetVerdictByTaskOfSpecificGroupAsync(int groupId, int taskId);
        Task<List<GroupDTO>> GetGroupsCreatdByUserAsync(int teacherId);
        Task<List<UserDTO>> GetUsersAsync(int groupId);
    }
}
