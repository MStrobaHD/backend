using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Services.Judge.ComplexityService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement.ComplexityController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplexityController : ControllerBase
    {
        private readonly IComplexityService _service;

        public ComplexityController(IComplexityService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetComplexitiesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetComplexitiesAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}