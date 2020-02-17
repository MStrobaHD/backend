using ESA_api.Mapping.DTO.EducationDTO.FlashcardSetsDTO;
using ESA_api.Services.Education.FlashcardSetService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Controllers.Education.FlashcardSetController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardSetController : ControllerBase
    {
        private readonly IFlashcardSetService _service;

        public FlashcardSetController(IFlashcardSetService service)
        {
            _service = service;
        }
        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetFlashcardSetsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetFlashcardSetsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // GET: api/Course/5
        [HttpGet("Course/{courseId}")]
        public async Task<IActionResult> GetFlashcardSetsOfCourseAsync(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetFlashcardSetsOfCourseAsync(courseId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        // GET: api/Course/5
        [HttpGet("{setId}")]
        public async Task<IActionResult> GetFlashcardSetAsync(int setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetFlashcardSetAsync(setId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddFlashcardSetAsync([FromBody] FlashcardSetAddDTO flashcardSetAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddFlashcardSetAsync(flashcardSetAddDTO);
            return Ok(result);
        }

        [HttpDelete("{setId}")]
        public async Task<IActionResult> DeleteFlashcardSetAsync([FromRoute] int setId)   // automapper
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flashcardSet = await _service.FindFlashcardSetAsync(setId);
            if (flashcardSet == false)
            {
                return NotFound();
            }

            await _service.DeleteFlashcardSetAsync(setId);

            return Ok(flashcardSet);
        }

    }
}