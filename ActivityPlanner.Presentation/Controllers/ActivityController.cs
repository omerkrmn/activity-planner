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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateActivity([FromBody] ActivityCreateRequestModel requestModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return Unauthorized();
            var response = await _service.ActivityService.CreateOneActivitiyAsync(requestModel);
            return Ok(response);
        }
    }
}
