using ESA_api.Mapping.DTO.EducationDTO.GroupsDTO;
using ESA_api.Services.Education.GroupService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Controllers.Education.GroupController
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _service;

        public GroupController(IGroupService service)
        {
            _service = service;
        }
        [HttpGet()]
        public async Task<IActionResult> GetGroupsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetGroupsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroupAsync(int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetGroupAsync(groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("CoursesToGroup/{groupId}")]
        public async Task<IActionResult> GetCoursesAssignedToGroupAsync(int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCoursesAssignedToGroupAsync(groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("CoursesToUser/{userId}")]
        public async Task<IActionResult> GetCoursesAssignedToUserAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCoursesAssignedToUserAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("TasksToGroup/{groupId}")]
        public async Task<IActionResult> GetTasksAssignedToGroupAsync(int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetTasksAssignedToGroupAsync(groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("TasksToUser/{userId}")]
        public async Task<IActionResult> GetTasksAssignedToUserAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetTasksAssignedToUserAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("groupAttendats/{groupId}")]
        public async Task<IActionResult> GetUsersAsync(int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUsersAsync(groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("groupStudentsResults/{groupId}")]
        public async Task<IActionResult> GetExamResultsByStudentOfSpecificGroupAsync(int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExamResultsByStudentOfSpecificGroupAsync(groupId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("groupVerdictByTask/")]
        public async Task<IActionResult> GetVerdictOfGroupByTask(int groupId, int taskId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetVerdictByTaskOfSpecificGroupAsync(groupId, taskId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("teacherGroups/{userId}")]
        public async Task<IActionResult> GetGroupsCreatdByUserAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetGroupsCreatdByUserAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddGroupAsync([FromBody] GroupAddDTO groupAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddGroupAsync(groupAddDTO);
            return Ok();
        }
        [HttpPost("CTGAssignment/")]
        public async Task<IActionResult> AssignCoursesToGroupAsync([FromBody] CourseAssignmentAddDTO courseAssignmentAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignCoursesToGroupAsync(courseAssignmentAddDTO);
            return Ok();
        }
        [HttpPost("TTGAssignment/")]
        public async Task<IActionResult> AssignTasksToGroupAsync([FromBody] TaskToGroupAssignmentAddDTO taskToGroupAssignmentAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignTasksToGroupAsync(taskToGroupAssignmentAddDTO);
            return Ok();
        }
        [HttpPost("STGAssignment/")]
        public async Task<IActionResult> AssignStudentsToGroupAsync([FromBody] GroupAssignmentAddDTO groupAssignmentAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignStudentsToGroupAsync(groupAssignmentAddDTO);
            return Ok();
        }
        [HttpPost("CTGAssignmentList/")]
        public async Task<IActionResult> AssignManyCoursesToManyGroupAsync([FromBody] CTGAssignmentDTO assignmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignManyCoursesToManyGroupAsync(assignmentDTO);
            return Ok();
        }
        [HttpPost("TTGAssignmentList/")]
        public async Task<IActionResult> AssignManyTasksToManyGroupAsync([FromBody] TTGAssignmentDTO assignmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignManyTasksToManyGroupAsync(assignmentDTO);
            return Ok();
        }
        [HttpPost("STGAssignmentList/")]
        public async Task<IActionResult> AssignManyStudentsToManyGroupAsync([FromBody] STGAssignmentDTO assignmentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AssignManyStudentsToManyGroupAsync(assignmentDTO);
            return Ok();
        }
        [HttpDelete("CTGResignation/")]
        public async Task<IActionResult> DeleteCoursesToGroupAssignmentAsync(int groupId, int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.DeleteCoursesToGroupAssignmentAsync(groupId, courseId);
            return NoContent();
        }
        [HttpDelete("TTGResignation/")]
        public async Task<IActionResult> DeleteTasksToGroupAssignmentAsync(int groupId, int taskId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.DeleteTasksToGroupAssignmentAsync(groupId, taskId);
            return NoContent();
        }
        [HttpDelete("STGResignation/")]
        public async Task<IActionResult> DeleteStudentsToGroupAssignmentAsync(int userId, int groupId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.DeleteStudentsToGroupAssignmentAsync(userId, groupId);
            return NoContent();
        }
    }
}
