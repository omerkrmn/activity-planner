﻿using ActivityPlanner.Entities.Models;
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
        Task<Subscriber> GetOneSubscriberAsync(int id, bool trackChanges);
        void CreateOneSubscriber(Subscriber subscriber);
        void UpdateOneSubscriber(Subscriber subscriber);
        void DeleteOneSubscriber(Subscriber subscriber);
        /// <summary>
        /// Girilen activity id'e ait olan tüm subscriber'ları getirir.
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        Task<List<Subscriber>> GetAllSubscribersByActivityAsync(int activityId,bool trackChanges);
    }
}
