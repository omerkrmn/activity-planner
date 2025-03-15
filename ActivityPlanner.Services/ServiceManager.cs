using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IActivityService> _activityService;
        private readonly Lazy<ISubscriberService> _subscriberService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _activityService = new Lazy<IActivityService>(() => new ActivityService(repositoryManager, mapper));
            _subscriberService = new Lazy<ISubscriberService>(() => new SubscriberService(repositoryManager, mapper));
        }
        public IActivityService ActivityService => _activityService.Value;

        public ISubscriberService SubscriberService => _subscriberService.Value;
    }
}
