using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.MultiSelectQuestionDTO;
using ESA_api.Mapping.DTO.EducationDTO.QuestionDTO.OrderedBlockDTO;
using ESA_api.Services.Education.QuestionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Education.QuestionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestionAsync([FromBody] QuestionAddDTO questionAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddQuestionAsync(questionAddDTO);
            return Ok(result);
        }
        [HttpPost("multiSelectQuestion")]
        public async Task<IActionResult> AddMultiSelectQuestionAsync([FromBody] MultiSelectQuestionAddDTO multiSelectQuestionAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddMultiSelectQuestionAsync(multiSelectQuestionAddDTO);
            return Ok(result);
        }
        [HttpPost("orderedBlock")]
        public async Task<IActionResult> AddOrderedBlockAsync([FromBody] OrderedBlockAddDTO orderedBlockAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddOrderedBlockAsync(orderedBlockAddDTO);
            return Ok(result);
        }
        [HttpGet("{examId}")]
        public async Task<IActionResult> GetQuestionsFromExamAsync(int examId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetQuestionsFromExamAsync(examId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("multiSelectQuestion/{examId}")]
        public async Task<IActionResult> GetMultiSelectQuestionsFromExamAsync(int examId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetMultiSelectQuestionsFromExamAsync(examId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("orderedBlock/{examId}")]
        public async Task<IActionResult> GetOrderedBlocksFromExamAsync(int examId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetOrderedBlocksFromExamAsync(examId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}