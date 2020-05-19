using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Mapping.DTO.CommonDTO.BadgeAssignmentDTO;
using ESA_api.Mapping.DTO.CommonDTO.BadgesDTO;
using ESA_api.Services.UserAction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESA_api.Controllers.UserAction
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        // GET: api/Course/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserDataAsync(int userId)
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
        [HttpGet()]
        public async Task<IActionResult> GetUsersAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUsersAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("addBadge/")]
        public async Task<IActionResult> AddBadgeAsync([FromBody] BadgeAddDTO badgeAddDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _service.AddBadgeAsync(badgeAddDTO);
            return Ok();
        }
        [HttpGet("userBadges/{id}")]
        public async Task<IActionResult> GetUserAssignedBadgesAsync(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserAssignedBadgesAsync(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("allBadges/")]
        public async Task<IActionResult> GetAllBadgesAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAllBadgesAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("userMarkStats/{id}")]
        public async Task<IActionResult> GetUserMarksStatsAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserMarkStatisticsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("markStats/")]
        public async Task<IActionResult> GetMarksStatsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAllMarkStatisticsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("userStats/")]
        public async Task<IActionResult> GetUserStatsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserStatisticsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("verdictStats/")]
        public async Task<IActionResult> GetVerdictStatsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAllVerdictsStatisticsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("userVerdictStats/{id}")]
        public async Task<IActionResult> GetUserVerdictStatsAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetUserVerdictsStatisticsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("assetStats/")]
        public async Task<IActionResult> GetAssetStatsAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.GetAssetsStatisticsAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}