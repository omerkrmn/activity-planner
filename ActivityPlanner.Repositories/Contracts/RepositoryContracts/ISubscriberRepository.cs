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
        Task<List<Subscriber>> GetAllSubscribersAsync(bool trackChanges);
        Task<Subscriber> GetOneSubscriberAsync(Guid id, bool trackChanges);
        void CreateOneSubscriber(Subscriber subscriber);
        void UpdateOneSubscriber(Subscriber subscriber);
        void DeleteOneSubscriber(Subscriber subscriber);
    }
}
