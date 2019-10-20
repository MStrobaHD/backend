using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using ESA_api.Services.Education.ExamService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Education.ExamController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _service;

        public ExamController(IExamService service)
        {
            _service = service;
        }
        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetExamsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExamsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Course/5
        [HttpGet("{examId}")]
        public async Task<IActionResult> GetExamAsync(int examId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExamAsync(examId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/Course/User/Id
        [HttpGet("Course/{courseId}")]
        public async Task<IActionResult> GetCourseExamsAsync(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCourseExamsAsync(courseId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //// GET: api/Course/Category/Id
        //[HttpGet("ExamType/{examTypeId}")]
        //public async Task<IActionResult> GetExamsByTypeAsync(int examTypeId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var result = await _service.GetExamsByTypeAsync(examTypeId);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> AddExamAsync([FromBody] ExamAddDTO examAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddExamAsync(examAddDTO);
            return Ok(result);
        }

        // PUT: api/Course/5
       
    }
}
