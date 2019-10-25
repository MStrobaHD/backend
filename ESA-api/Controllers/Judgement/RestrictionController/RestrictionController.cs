using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.JudgeDTO.RestrictionsDTO;
using ESA_api.Services.Judge.RestrictionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement.RestrictionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly IRestrictionService _service;

        public RestrictionController(IRestrictionService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddRestrictionAsync([FromBody] RestrictionAddDTO restrictionAddDTO)
        {
            if (restrictionAddDTO is null)
            {
                throw new ArgumentNullException(nameof(restrictionAddDTO));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddRestrictionAsync(restrictionAddDTO);
            return Ok(result);
        }
    }
}