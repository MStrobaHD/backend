using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.JudgmentDTO;
using ESA_api.Models;
using ESA_api.Services.Judge.ExternalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController : ControllerBase
    {
        private readonly AppDatabaseContext _context;
        private readonly IExternalService _service;

        public JudgeController(AppDatabaseContext context, IExternalService service)
        {
            _context = context;
            _service = service;
        }

        // POST: api/Course
        //[HttpPost]
        //public async Task<IActionResult> AddCourseAsync([FromBody] SourceCode sourceCode)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // source code to file
        //    // source code calculate coplexity
        //    // 



        //    System.Diagnostics.Process process = new System.Diagnostics.Process();
        //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        //   // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

        //    // run cmd in hidden mode
        //    startInfo.FileName = "cmd.exe";
        //    // run csc.exe <filename.cs> -> compile file to exe
        //    startInfo.Arguments = "csc.exe";
        //    process.StartInfo = startInfo;
        //    process.Start();



        //    return Ok(startInfo);
        //}
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync([FromBody] Submission submission)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var submissionPrepared =  _service.ReplaceAsync(submission);
            var token = await _service.createSubmissionAsync(submissionPrepared);

            if(token != null)
            {
                JsonCompilationResult result;
                result = await _service.GetResultAsync(token);

                while (result.stdout == null && result.compile_output == null)
                {
                    result = await _service.GetResultAsync(token);
                }
                var finalResult = await _service.GetFinalResultAsync(token);
                return Ok(finalResult);
            } else
            {
                return BadRequest("Token nieprawidłowy lub jego brak");
            }
 
        }
    }
}