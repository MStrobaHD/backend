using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.ExamResultDTO;
using ESA_api.Services.Education.ExamResultService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Education.ExamResultController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _service;

        public ExamResultController(IExamResultService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddExamResultAsync([FromBody] ExamResultAddDTO examResultAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddExamResultAsync(examResultAddDTO);
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCourseExamsAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetExamResultsAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}