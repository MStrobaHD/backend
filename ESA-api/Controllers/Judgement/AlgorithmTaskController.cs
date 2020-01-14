using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Services.Judge.AlgorithmTaskService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmTaskController : ControllerBase
    {
        private readonly IAlgorithmTaskService _service;

        public AlgorithmTaskController(IAlgorithmTaskService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddAlgorithmAsync([FromBody] AlgorithmTaskAddDTO algorithmTaskAddDTO)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddAlgorithmTaskDTO(algorithmTaskAddDTO);
            return Ok(result);
        }
        [HttpPost("rating")]
        public async Task<IActionResult> RateAsync([FromBody] RatingDTO ratingDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.RateAsync(ratingDTO);
            return Ok(result);
        }
        // GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetAlgorithmTasksForDisplayAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAlgorithmTasksForDisplayAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlgorithmTaskForSolveAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAlgorithmTaskForSolveAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}