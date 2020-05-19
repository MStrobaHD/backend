using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.GroupRepository
{
    public interface IGroupRepository
    {
        Task AddGroupAsync(Group group);
        Task AssignCoursesToGroupAsync(CourseAssignment assignment);
        Task AssignTasksToGroupAsync(TaskToGroupAssignment assignment);
        Task AssignStudentsToGroupAsync(GroupAssignment assignment);

        Task DeleteCoursesToGroupAssignmentAsync(int groupId, int courseId);
        Task DeleteTasksToGroupAssignmentAsync(int groupId, int taskId);
        Task DeleteStudentsToGroupAssignmentAsync(int userId, int groupId);

        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int groupId);

        Task<List<Group>> GetGroupsAsync();
        Task<Group> GetGroupAsync(int groupId);
        Task<Group> GetCoursesAssignedToGroupAsync(int groupId);
        Task<Group> GetTasksAssignedToGroupAsync(int groupId);
        Task<User> GetTasksAssignedToUserAsync(int userId);
        Task<User> GetCoursesAssignedToUserAsync(int userId);
        Task<AlgorithmTask> GetAlgorithmTaskAsync(int algorithmTaskId);
        //Task<int> GetExamResultOfSpecificGroup(int groupId);
        Task<List<Group>> GetGroupsCreatedByMeAsync(int userId);
        Task<Group> GetUsersAsync(int groupId);
        Task<Group> GetGroupVerdictByTask(int groupId);
    }
}
