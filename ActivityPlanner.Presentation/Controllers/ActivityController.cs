using ActivityPlanner.Entities.DTOs.Activites;
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
    public class ActivityController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ActivityController(IServiceManager service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllActivity()
        {
            var subscribers = await _service.ActivityService.GetAllActivitiesAsync(false);
            return Ok(subscribers);
        }
        [HttpGet("GetAllActivityByUserName")]
        public async Task<IActionResult> GetAllActivityByUserName([FromQuery] string userName)
        {
            var activities = await _service.ActivityService.GetAllActivitiesByUser(false, userName);
            return Ok(activities);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCreateRequestModel requestModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var response = await _service.ActivityService.CreateOneActivitiyAsync(requestModel, userId);
            return Ok(response);
        }
        [HttpGet("GetActivityByShortLink/{userName}/{activityName}")]
        public async Task<IActionResult> GetActivityByShortLink([FromRoute] string userName, [FromRoute] string activityName)
        {
            var activity = await _service.ActivityService.GetOneActivityAsync(userName, activityName);
            if (activity == null)
                return NotFound();
            return Ok(activity);
        }
    }
}
