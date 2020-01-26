using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Services.Common.CloudUploadService;
using ESA_api.Services.UserAction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.UserAction
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardUserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ICloudUploadService _cloudUploadService;

        public StandardUserController(IUserService service, ICloudUploadService cloudUploadService)
        {
            _service = service;
            _cloudUploadService = cloudUploadService;
        }
        // GET: api/Course/5
        [HttpGet("addedbyuser/{userId}")]
        public async Task<IActionResult> GetUserAddMaterialAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cloudUploadService.GetUserAddedMaterialAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("addedbycourseowner/{userId}")]
        public async Task<IActionResult> GetCourseOwnerAddMaterialAsync(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserDataAsync(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}