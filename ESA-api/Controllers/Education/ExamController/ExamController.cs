using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.ExamsDTO;
using ESA_api.Services.Education.ExamService;
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

        [HttpGet("Course/NotOpened/")]
        public async Task<IActionResult> GetExamsNotOpenedAsync(int courseId, int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAvailableExamsAsync(courseId, userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

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
    }
}
