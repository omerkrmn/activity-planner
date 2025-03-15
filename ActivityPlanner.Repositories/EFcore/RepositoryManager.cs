
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;

namespace ActivityPlanner.Repositories.EFcore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IActivityRepository> _activityRepository;
        private readonly Lazy<ISubscriberRepository> _subscriberRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _activityRepository = new Lazy<IActivityRepository>(() => new ActivityRepository(_context));
            _subscriberRepository = new Lazy<ISubscriberRepository>(() => new SubscriberRepository(_context));
        }
        public IActivityRepository Activity => _activityRepository.Value;
        public ISubscriberRepository Subscriber => _subscriberRepository.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
