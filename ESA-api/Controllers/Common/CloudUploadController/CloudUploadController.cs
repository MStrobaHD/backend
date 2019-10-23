using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using ESA_api.Helpers;
using ESA_api.Mapping.DTO.CommonDTO.CloudUploadDTO;
using ESA_api.Services.Common.CloudUploadService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ESA_api.Controllers.Common.CloudUploadController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudUploadController : ControllerBase
    {
        private readonly IOptions<CloudinarySettings> _options;
        private readonly ICloudUploadService _service;

        public CloudUploadController(IOptions<CloudinarySettings> options, ICloudUploadService service)
        {
            _options = options;
            _service = service;
            Account acc = new Account(
               _options.Value.CloudName,
               _options.Value.ApiKey,
               _options.Value.ApiSecret);
        }
        [RequestSizeLimit(40000000)]
        [HttpPost("{id}/{lessonId}")]
        public async Task<IActionResult> AddCloudAssetAsync([FromForm]CloudinaryAsset cloudinaryAsset, int id, int lessonId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asset = await _service.AddCloudAssetAsync(cloudinaryAsset, id, lessonId);
            return Ok(asset);
        }
    }
}