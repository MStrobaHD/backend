using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using ESA_api.Helpers;
using ESA_api.Mapping.DTO.CommonDTO.CloudUploadDTO;
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

        public CloudUploadController(IOptions<CloudinarySettings> options)
        {
            _options = options;

            Account acc = new Account(
               _options.Value.CloudName,
               _options.Value.ApiKey,
               _options.Value.ApiSecret);
        }
        //[RequestSizeLimit(40000000)]
        //[HttpPost("{id}")]
        //public async Task<IActionResult> AddImageAsync([FromForm]CloudinaryAsset cloudinaryAsset, int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var asset = await _service.AddImage(cloudinaryAsset, id);
        //    return Ok(asset);
        //}
    }
}