using ActivityPlanner.API.Attributes;
using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.RequestFeatures;
using ActivityPlanner.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace ActivityPlanner.Presentation.Controllers
{
    [ApiController]
    [Route("activities")]
    [LogAction]
    public class ActivityController : ControllerBase
    {
        private readonly IServiceManager _service;
        private readonly ILogger<ActivityController> _logger;

        public ActivityController(IServiceManager service, ILogger<ActivityController> logger)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityCreateDto requestModel, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var response = await _service.ActivityService.CreateAsync(requestModel, userId, ct);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ActivityParameters parameters, CancellationToken ct)
        {
            var activities = await _service.ActivityService.GetAllAsync(parameters, ct);
            return Ok(activities);
        }

        [HttpGet("{activityId:int}")]
        public async Task<IActionResult> GetById([FromRoute] int activityId, CancellationToken ct)
        {
            var activity = await _service.ActivityService.GetByIdAsync(activityId, ct);
            if (activity == null)
                return NotFound();

            return Ok(activity);
        }

        [Authorize]
        [HttpDelete("{activityId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int activityId, CancellationToken ct)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            await _service.ActivityService.DeleteAsync(activityId, userId, ct);
            return NoContent();
        }
    }
}
