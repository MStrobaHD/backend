using ESA_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Education.GroupRepository
{
    public class GroupRepository: IGroupRepository
    {
        private readonly AppDatabaseContext _context;

        public GroupRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddGroupAsync(Group group)
        {
            _context.Group.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task AssignCoursesToGroupAsync(CourseAssignment assignment)
        {
            _context.CourseAssignment.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task AssignStudentsToGroupAsync(GroupAssignment assignment)
        {
            _context.GroupAssignment.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task AssignTasksToGroupAsync(TaskToGroupAssignment assignment)
        {
            _context.TaskToGroupAssignment.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCoursesToGroupAssignmentAsync(int groupId, int courseId)
        {
            var assignment = await _context.CourseAssignment.Where(course => course.GroupId == groupId & course.CourseId == courseId).SingleOrDefaultAsync();
            _context.CourseAssignment.Remove(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            var group = await _context.Group.FindAsync(groupId);
            _context.Group.Remove(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentsToGroupAssignmentAsync(int userId, int groupId)
        {
            var assignment = await _context.GroupAssignment.Where(course => course.UserId == userId & course.GroupId == groupId).SingleOrDefaultAsync();
            _context.GroupAssignment.Remove(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTasksToGroupAssignmentAsync(int groupId, int taskId)
        {
            var assignment = await _context.TaskToGroupAssignment.Where(course => course.GroupId == groupId & course.AlgorithmTaskId == taskId).SingleOrDefaultAsync();
            _context.TaskToGroupAssignment.Remove(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task<AlgorithmTask> GetAlgorithmTaskAsync(int algorithmTaskId)
        {
            return await _context.AlgorithmTask
                .Include(user => user.User)
                .Include(complexity => complexity.Complexity)
                .Include(algorithmCategory => algorithmCategory.AlgorithmCategory)
                .Include(level => level.Level)
                .Where(task => task.Id == algorithmTaskId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<Group> GetCoursesAssignedToGroupAsync(int groupId) 
        {
            return await _context.Group
                .Include(group => group.CourseAssignment)
                .ThenInclude(assignment => assignment.Course)
                .Where(group => group.Id == groupId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetCoursesAssignedToUserAsync(int userId)
        {
            return await _context.User
               .Include(user => user.GroupAssignment)
               .ThenInclude(assignment => assignment.Group)
               .ThenInclude(group => group.CourseAssignment)
               .ThenInclude(assignment => assignment.Course)
               .Where(user => user.Id == userId)
               .AsNoTracking()
               .SingleOrDefaultAsync();
        }

        public async Task<Group> GetGroupAsync(int groupId)
        {
            return await _context.Group
                .Where(group => group.Id == groupId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _context.Group.ToListAsync();
        }

        public async Task<List<Group>> GetGroupsCreatedByMeAsync(int userId)
        {
            return await _context.Group
                .Where(group => group.TeacherId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Group> GetGroupVerdictByTask(int groupId)
        {
            var query = (from verdict in _context.Set<Verdict>()
                        join user in _context.Set<User>()
                        on verdict.UserId equals user.Id
                        join assignment in _context.Set<GroupAssignment>()
                        on user.Id equals assignment.UserId
                        join grupa in _context.Set<Group>()
                        on assignment.GroupId equals grupa.Id
                        where grupa.Id == groupId
                        select new { verdict, user, assignment, grupa }).AsQueryable();

            return await _context.Group
               .Include(assignment => assignment.GroupAssignment)
               .ThenInclude(user => user.User)
               .ThenInclude(verdict => verdict.Verdict)
               .Where(group => group.Id == groupId)
               .AsNoTracking()
               .SingleOrDefaultAsync();
        }

        public async Task<Group> GetTasksAssignedToGroupAsync(int groupId)
        {
            return await _context.Group
                .Include(group => group.TaskToGroupAssignment)
                .ThenInclude(assignment => assignment.AlgorithmTask)
                .Where(group => group.Id == groupId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }

        public async Task<User> GetTasksAssignedToUserAsync(int userId)
        {
            return await _context.User
               .Include(user => user.GroupAssignment)
               .ThenInclude(assignment => assignment.Group)
               .ThenInclude(group => group.TaskToGroupAssignment)
               .ThenInclude(assignment => assignment.AlgorithmTask)
               .Where(user => user.Id == userId)
               .AsNoTracking()
               .SingleOrDefaultAsync();
        }

        public async Task<Group> GetUsersAsync(int groupId)
        {
            return await _context.Group
                .Include(assignment => assignment.GroupAssignment)
                .ThenInclude(user => user.User)
                .Where(group => group.Id == groupId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }


        public async Task UpdateGroupAsync(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
