using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Services.Judge.AlgorithmCategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Judgement.AlgorithmCategory
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlgorithmCategoryController : ControllerBase
    {
        private readonly IAlgorithmCategoryService _service;

        public AlgorithmCategoryController(IAlgorithmCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCategoriesAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}