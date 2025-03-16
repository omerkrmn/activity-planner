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

    public class SubscriberController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SubscriberController(IServiceManager service)
        {
            _service = service;
        }

      
    }
}
