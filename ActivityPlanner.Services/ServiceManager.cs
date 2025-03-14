using ActivityPlanner.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IActivityService _activityService;
        private readonly ISubscriberService _subscriberService;
        public ServiceManager(IActivityService activityService,ISubscriberService subscriberService)
        {
            _activityService = activityService;
            _subscriberService = subscriberService;
        }
        public IActivityService ActivityService => _activityService;

        public ISubscriberService SubscriberService => _subscriberService;
    }
}
