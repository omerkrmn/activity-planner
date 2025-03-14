using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface IServiceManager
    {
        IActivityService ActivityService { get; }   
        ISubscriberService SubscriberService { get; }
    }
}
