using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.Contracts
{
    public interface IRepositoryManager
    {
       
        IActivityRepository Activity { get; }
        ISubscriberRepository Subscriber { get; }
        Task SaveAsync();
    }
}
