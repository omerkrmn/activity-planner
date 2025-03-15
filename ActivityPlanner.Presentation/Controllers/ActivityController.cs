using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController: ControllerBase
    {
        private readonly IServiceManager _service;

        public ActivityController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubscribers()
        {
            var subscribers = await _service.SubscriberService.GetAllSubscribersAsync(false);
            return Ok(subscribers);
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody]ActivityCreateRequestModel requestModel)
        {
            var response = await _service.ActivityService.CreateOneActivitiyAsync(requestModel);
            return Ok(response);
        }
    }
}
