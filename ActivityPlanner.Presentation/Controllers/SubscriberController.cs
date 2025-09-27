using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityPlanner.Presentation.Controllers
{
    [ApiController]
    [Route("activities/{activityId:int}/subscribers")]
    public class SubscriberController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SubscriberController(IServiceManager service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> GetByActivity([FromRoute] int activityId, CancellationToken ct)
        {
            if (activityId <= 0)
                return BadRequest("ActivityId must be greater than 0.");

            var subscribers = await _service.SubscriberService.GetByActivityIdAsync(activityId, ct);
            return Ok(subscribers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubscriberCreateDto dto, [FromRoute] int activityId, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var response = await _service.SubscriberService.CreateAsync(dto, activityId, ct);
            return StatusCode(StatusCodes.Status201Created, response);  
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] SubscriberUpdateDto dto, [FromRoute] int activityId, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _service.SubscriberService.UpdateAsync(dto, activityId, ct);
            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromBody] SubscriberDeleteDto dto, [FromRoute] int activityId, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.SubscriberService.DeleteAsync(dto, activityId, ct);
            return NoContent();
        }
    }
}
