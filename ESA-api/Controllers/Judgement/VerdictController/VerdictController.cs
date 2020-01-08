﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.JudgeDTO.VerdictsDTO;
using ESA_api.Services.Judge.VerdictService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement.VerdictController
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerdictController : ControllerBase
    {
        private readonly IVerdictService _service;

        public VerdictController(IVerdictService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddVerdictmAsync([FromBody] VerdictAddDTO verdictAddDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddVerdictAsync(verdictAddDTO);
            return Ok(result);
        }
    }
}