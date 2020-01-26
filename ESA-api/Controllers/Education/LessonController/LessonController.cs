using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.EducationDTO.LessonsDTO;
using ESA_api.Services.Education.LessonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.Education.LessonController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> AddLessonAsync([FromBody] LessonAddDTO lessonAddDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddLessonAsync(lessonAddDTO);
            return Ok(result);
        }
        [HttpPost("serverAsset")]
        public async Task<IActionResult> AddServerAssetAsync([FromBody] ServerAssetAddDTO serverAssetAddDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddServerAssetAsync(serverAssetAddDTO);
            return Ok(result);
        }
        [HttpPost("cloudAsset")]
        public async Task<IActionResult> AddCloudAssetAsync([FromBody] CloudAssetAddDTO cloudAssetAddDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddCloudAssetAsync(cloudAssetAddDTO);
            return Ok(result);
        }
        [HttpGet("list/{courseId}")]
        public async Task<IActionResult> GetCourseLessonsAsync(int courseId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCourseLessonsAsync(courseId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }

}
