using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SubscriberService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SubscriberResponseModel> CreateOneSubscriberAsync(SubscriberCreateModel subscriber)
        {
            if (subscriber == null) throw new ArgumentNullException(nameof(subscriber));
            var tempActivity = _mapper.Map<Subscriber>(subscriber);
            _repositoryManager.Subscriber.CreateOneSubscriber(tempActivity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<SubscriberResponseModel>(tempActivity);
        }

        public async Task<SubscriberResponseModel> DeleteOneSubscriberAsync(SubscriberDeleteModel subscriber)
        {
            //if(subscriber == null) throw new ArgumentNullException( nameof(subscriber));
            //var check = await _repositoryManager.Subscriber.GetOneSubscriberAsync(subscriber.)
            throw new NotImplementedException();
            //sanırım burada biraz işler farklı olacak 
        }

        public async Task<List<SubscriberResponseModel>> GetAllSubscribersAsync(bool trackChanges)
        {
            var subs = await _repositoryManager.Subscriber.GetAllSubscribersAsync(trackChanges);
            var subsResponse = _mapper.Map<List<SubscriberResponseModel>>(subs);
            return subsResponse;
        }

        public async Task<SubscriberResponseModel> GetOneSubscriberAsync(int id, bool trackChanges)
        {
            var sub = await _repositoryManager.Subscriber.GetOneSubscriberAsync(id, trackChanges);
            if (sub == null) throw new ArgumentNullException();
            return _mapper.Map<SubscriberResponseModel>(sub);
        }

        public async Task<SubscriberResponseModel> UpdateOneSubscriberAsync(SubscriberUpdateModel subscriber)
        {
            if (subscriber is null) throw new ArgumentNullException();
            var sub = await _repositoryManager.Subscriber.GetOneSubscriberAsync(subscriber.SubscriberId, true);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<SubscriberResponseModel>(sub);
        }
    }
}
