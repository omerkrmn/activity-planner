using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.EFcore
{
    public class SubscriberRepository : RepositoryBase<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(RepositoryContext context) : base(context){}

        public async Task<IReadOnlyList<Subscriber>> GetAllAsync(bool trackChanges, CancellationToken ct = default) =>
             await FindAll(trackChanges)
                  .ToListAsync(ct);
        public async Task<IReadOnlyList<Subscriber>> GetByActivityIdAsync(int activityId, bool trackChanges, CancellationToken ct = default) =>
             await FindByCondition(b => b.Activity.Id.Equals(activityId), trackChanges)
                  .OrderBy(s => s.SubscriberName)
                  .ToListAsync(ct);

        public async Task<Subscriber?> GetByIdAsync(int id, bool trackChanges, CancellationToken ct = default) =>
             await FindByCondition(b => b.SubscriberId.Equals(id), trackChanges)
                  .SingleOrDefaultAsync(ct);
    }
}
