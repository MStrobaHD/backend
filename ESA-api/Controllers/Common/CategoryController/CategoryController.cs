using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.CommonDTO.CategoryDTO;
using ESA_api.Services.Common.CategoryService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Controllers.Common.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Course
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

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryAsync(int categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetCategoryAsync(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> AddCourseAsync([FromBody] CategoryAddDTO categoryAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.AddCategoryAsync(categoryAddDTO);
            return Ok(result);
        }

        // PUT: api/Course/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseAsync(int categoryId, CategoryAddDTO categoryAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (categoryAddDTO == null)
            {
                throw new ArgumentNullException(nameof(categoryAddDTO));
            }

            try
            {
                var result = await _service.UpdateCategoryAsync(categoryId, categoryAddDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.CategoryExistsAsync(categoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] int categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _service.FindCategoryAsync(categoryId);
            if (course == false)
            {
                return NotFound();
            }

            await _service.DeleteCategoryAsync(categoryId);

            return NoContent();
        }
    }
}
