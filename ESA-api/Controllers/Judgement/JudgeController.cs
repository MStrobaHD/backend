using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.JudgeDTO.JudgmentDTO;
using ESA_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgeController : ControllerBase
    {
        private readonly AppDatabaseContext _context;

        public JudgeController(AppDatabaseContext context)
        {
            _context = context;
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync([FromBody] SourceCode sourceCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // source code to file
            // source code calculate coplexity
            // 



            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
           // startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            // run cmd in hidden mode
            startInfo.FileName = "cmd.exe";
            // run csc.exe <filename.cs> -> compile file to exe
            startInfo.Arguments = "csc.exe";
            process.StartInfo = startInfo;
            process.Start();

            
            
            return Ok(startInfo);
        }
    }
}