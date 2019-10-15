using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.CoursesDTO;
using ESA_api.Services.Education.CourseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Controllers.Education.CourseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetCoursesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCoursesAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursesAsync(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCourseAsync(courseId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Course/User/Id
        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetCoursesCreatedByUserAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCoursesCreatedByUserAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Course/Category/Id
        [HttpGet("Category/{id}")]
        public async Task<IActionResult> GetCoursesByCategoryAsync(int categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetCoursesByCategoryAsync(categoryId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync([FromBody] CourseAddDTO courseAddDTO)
        {
            courseAddDTO.Date = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddCourseAsync(courseAddDTO);
            return Ok(result);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseAsync(int courseId, CourseAddDTO courseAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (courseAddDTO == null)
            {
                throw new ArgumentNullException(nameof(courseAddDTO));
            }

            if (await _service.CourseExistsAsync(courseId))
                return BadRequest("Course does not exists");
            try
            {
                var result = await _service.UpdateCourseAsync(courseId, courseAddDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.CourseExistsAsync(courseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Course/5
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindCourseAsync(courseId);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteCourseAsync(courseId);

            return NoContent();
        }
    }
}
