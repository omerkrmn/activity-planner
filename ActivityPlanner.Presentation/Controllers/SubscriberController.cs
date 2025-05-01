using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActivityPlanner.Presentation.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class SubscriberController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber([FromBody] SubscriberCreateModel subscriberCreateModel)
        {
            var response = await _service.SubscriberService.CreateOneSubscriberAsync(subscriberCreateModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(SubscriberUpdateModel subscriberUpdateModel)
        {
            var response = await _service.SubscriberService.UpdateOneSubscriberAsync(subscriberUpdateModel);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSubscribe(SubscriberDeleteModel subscriberDeleteModel)
        {
            await _service.SubscriberService.DeleteOneSubscriberAsync(subscriberDeleteModel);
            return NoContent();
        }

    }
}
