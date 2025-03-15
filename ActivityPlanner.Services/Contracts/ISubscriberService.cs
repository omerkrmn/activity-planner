using ActivityPlanner.Entities.DTOs.Subscriber;
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
        Task<List<SubscriberResponseModel>> GetAllSubscribersAsync(bool trackChanges);
        Task<SubscriberResponseModel> GetOneSubscriberAsync(Guid id, bool trackChanges);
        Task<SubscriberResponseModel> CreateOneSubscriberAsync(SubscriberCreateModel subscriber);
        Task<SubscriberResponseModel> UpdateOneSubscriberAsync(SubscriberUpdateModel subscriber);
        Task<SubscriberResponseModel> DeleteOneSubscriberAsync(SubscriberDeleteModel subscriber);
    }
}
