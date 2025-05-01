using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Services;
using ActivityPlanner.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController(IServiceManager service/*, IRedisCacheService redisCacheService*/) : ControllerBase
    {
        private readonly IServiceManager _service=service;

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCreateRequestModel requestModel)
        {
            if(!ModelState.IsValid)
                throw new ArgumentNullException(nameof(requestModel));

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var response = await _service.ActivityService.CreateOneActivitiyAsync(requestModel, userId);
            return Ok(response);
        }
        [HttpGet("{userName}/{activityName}")]
        public async Task<IActionResult> GetOneActivity([FromRoute] string userName, [FromRoute] string activityName)
        {
            //var cacheKey = $"activity:{userName}:{activityName}";
            //var cachedActivity = await _service.RedisCacheService.GetCacheAsync<ActivityResponseModel>(cacheKey);
            
            //if (cachedActivity != null)
            //    return Ok(cachedActivity);

            var activity = await _service.ActivityService.GetOneActivityAsync(userName, activityName);
            if (activity == null)
                return NotFound();
            //await _service.RedisCacheService.SetCacheAsync(cacheKey, activity, TimeSpan.FromSeconds(10));
            return Ok(activity);
        }
        [Authorize]
        [HttpDelete("{activityName}")]
        public async Task<IActionResult> DeleteActivity([FromRoute] string activityName)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
                return Unauthorized();
            await _service.ActivityService.DeleteOneActivitiyAsync(userId,activityName);
            return NoContent();
        }
    }
}
