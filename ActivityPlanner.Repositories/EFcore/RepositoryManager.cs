
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;

namespace ActivityPlanner.Repositories.EFcore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IActivityRepository _activityRepository;
        private readonly ISubscriberRepository _subscriberRepository;

        public RepositoryManager(RepositoryContext context, IActivityRepository activityRepository, ISubscriberRepository subscriberRepository)
        {
            _context = context;
            _activityRepository = activityRepository;
            _subscriberRepository = subscriberRepository;
        }
        public IActivityRepository Activity => _activityRepository;
        public ISubscriberRepository Subscriber => _subscriberRepository;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
