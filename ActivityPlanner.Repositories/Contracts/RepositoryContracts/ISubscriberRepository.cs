using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.Contracts.RepositoryContracts
{
    public interface ISubscriberRepository : IRepositoryBase<Subscriber>
    {
        Task<IReadOnlyList<Subscriber>> GetAllAsync(bool trackChanges, CancellationToken ct = default);
        Task<Subscriber?> GetByIdAsync(int id, bool trackChanges, CancellationToken ct = default);
        Task<IReadOnlyList<Subscriber>> GetByActivityIdAsync(int activityId, bool trackChanges, CancellationToken ct = default);
    }
}
