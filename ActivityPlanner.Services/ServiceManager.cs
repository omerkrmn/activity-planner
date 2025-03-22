using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ActivityPlanner.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly Lazy<IMailService> _mailService;
        private readonly Lazy<IActivityService> _activityService;
        private readonly Lazy<ISubscriberService> _subscriberService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _activityService = new Lazy<IActivityService>(() => new ActivityService(repositoryManager, mapper));
            _subscriberService = new Lazy<ISubscriberService>(() => new SubscriberService(repositoryManager, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(mapper, userManager, configuration));
            _mailService = new Lazy<IMailService>(()=>new MailService(configuration));
        }
        public IActivityService ActivityService => _activityService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public ISubscriberService SubscriberService => _subscriberService.Value;
        public IMailService MailService => _mailService.Value;
    }
}
