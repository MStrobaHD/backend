using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Services.Judge.VerificationDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement.VerificationDataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationDataController : ControllerBase
    {
        private readonly IVerificationDataService _service;

        public VerificationDataController(IVerificationDataService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddVerificationDataAsync([FromBody] VerificationDataAddDTO verificationDataAddDTO)
        {
            if (verificationDataAddDTO is null)
            {
                throw new ArgumentNullException(nameof(verificationDataAddDTO));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddVerificationDataAsync(verificationDataAddDTO);
            return Ok(result);
        }
    }
}