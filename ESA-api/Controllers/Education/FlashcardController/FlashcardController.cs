using ESA_api.Mapping.DTO.EducationDTO.FlashcardsDTO;
using ESA_api.Services.Education.FlashcardService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Controllers.Education.FlashcardController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlashcardController : ControllerBase
    {
        private readonly IFlashcardService _service;

        public FlashcardController(IFlashcardService service)
        {
            _service = service;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashcard([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flashcard = await _service.FindFlashcardAsync(id);
            if (flashcard == false)
            {
                return NotFound();
            }

            await _service.DeleteFlashcardAsync(id);

            return Ok(flashcard);
        }
        [HttpPost]
        public async Task<IActionResult> AddFlashcardAsync([FromBody]FlashcardAddDTO flashcardAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddFlashcardAsync(flashcardAddDTO);
            return Ok(result);
        }
        [HttpGet("{setId}")]
        public async Task<IActionResult> GetFlashcardList(int setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetFlashcardsListAsync(setId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet("List/{setId}")]
        public async Task<IActionResult> GetSetFlashcardList(int setId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.GetSetFlashcardsListAsync(setId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
