using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.JudgmentDTO;
using ESA_api.Model;
using ESA_api.Services.Judge.CodeAnalyzeService;
using ESA_api.Services.Judge.JudgeEngineService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController : ControllerBase
    {
        private readonly ICodeAnalyzeService _codeAnalyzeService;
        private readonly IJudgeEngineService _judgeEngineService;

        public JudgeController(ICodeAnalyzeService codeAnalyzeService,
                               IJudgeEngineService judgeEngineService)
        {
            _codeAnalyzeService = codeAnalyzeService;
            _judgeEngineService = judgeEngineService;
        }

        [HttpPost("controlFlowGraph")]
        public async Task<IActionResult> GetControlFlowGraphAsync([FromBody] Source source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _codeAnalyzeService.CreateControlFlowGraphForDisplay(source.source_code);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("metrics")]
        public async Task<IActionResult> GetMetrics([FromBody] Source source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _codeAnalyzeService.GetMetricsAsync(source.source_code);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CompileAndExecuteCode([FromBody] Submission submission)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _judgeEngineService.createSubmissionAsync(submission);

            if (token != null)
            {
                JsonCompilationResult result;
                result = await _judgeEngineService.GetResultAsync(token);

                while (result.stdout == null && result.compile_output == null)
                {
                    result = await _judgeEngineService.GetResultAsync(token);
                }
                var finalResult = await _judgeEngineService.GetFinalResultAsync(token);
                return Ok(finalResult);
            }
            else
            {
                return BadRequest("Token nieprawidłowy lub jego brak");
            }

        }
        [HttpPost("input")]
        public async Task<IActionResult> CompileAndExecuteCodeWithInput([FromBody] SubmissionWithInput submission)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _judgeEngineService.createSubmissionWithInputAsync(submission);

            if (token != null)
            {
                JsonCompilationResult result;
                result = await _judgeEngineService.GetResultAsync(token);

                while (result.stdout == null && result.compile_output == null)
                {
                    result = await _judgeEngineService.GetResultAsync(token);
                }
                var finalResult = await _judgeEngineService.GetFinalResultAsync(token);
                return Ok(finalResult);
            }
            else
            {
                return BadRequest("Token nieprawidłowy lub jego brak");
            }

        }
        [HttpPost("judge")]
        public async Task<IActionResult> JudgeSolutionAsync([FromBody] SubmissionWithInput submission)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _judgeEngineService.JudgeSolution(submission);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}