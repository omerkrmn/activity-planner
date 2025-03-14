using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface ISubscriberService
    {
        Task<List<Subscriber>> GetAllSubscribersAsync(bool trackChanges);
        Task<Subscriber> GetOneSubscriberAsync(int id, bool trackChanges);
        void CreateOneSubscriber(Subscriber subscriber);
        void UpdateOneSubscriber(Subscriber subscriber);
        void DeleteOneSubscriber(Subscriber subscriber);
    }
}
