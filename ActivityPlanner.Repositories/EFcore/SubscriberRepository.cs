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
        public SubscriberRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneSubscriber(Subscriber subscriber) => Create(subscriber);

        public void DeleteOneSubscriber(Subscriber subscriber) => Delete(subscriber);

        public async Task<List<Subscriber>> GetAllSubscribersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(s => s.SubscriberId).ToListAsync();
        }

        public async Task<Subscriber> GetOneSubscriberAsync(int id, bool trackChanges)=> await FindByCondition(b => b.SubscriberId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneSubscriber(Subscriber subscriber)=>Delete(subscriber);
    }
}
