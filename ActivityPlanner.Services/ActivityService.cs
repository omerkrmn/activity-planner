﻿using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Exceptions;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ActivityService(IRepositoryManager repositoryManager, IMapper mapper) : IActivityService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IMapper _mapper = mapper;

        public async Task<ActivityResponseModel> CreateOneActivitiyAsync(ActivityCreateRequestModel activity, string userId)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            var now = DateTime.UtcNow;
            
            if (activity.LastRegistrationDate < now)
                throw new ArgumentException("LastRegistrationDate cannot be earlier than the current UTC time.", nameof(activity.LastRegistrationDate));

            var newActivity = _mapper.Map<Activity>(activity);
            newActivity.AppUserId = userId;
            newActivity.CreatedAt = now;
            newActivity.LastUpdatedAt = now;
            _repositoryManager.Activity.CreateOneActivitiy(newActivity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<ActivityResponseModel>(newActivity);
        }


        public async Task<ActivityResponseModel> DeleteOneActivitiyAsync(string userId, string activityName)
        {
            if (string.IsNullOrEmpty(activityName))
                throw new ArgumentNullException(nameof(activityName));
            var activity = await _repositoryManager.Activity.FindAll(true).Include(u => u.AppUser).Where(u => u.AppUser.Id.Equals(userId)).SingleOrDefaultAsync();
            if (activity == null)
                throw new NotFoundException(nameof(AppUser));

            var userName = activity.AppUser.UserName;
            if (userName == null)
                throw new NotFoundException(nameof(AppUser));
            var result = await _repositoryManager.Activity.GetOneActivityAsync(userName!, activityName, true);

            _repositoryManager.Activity.Delete(result);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ActivityResponseModel>(result);
        }

        public async Task<List<ActivityResponseModel>> GetAllActivitiesAsync(bool trackChanges)
        {
            var activities = await _repositoryManager.Activity.GetAllActivitiesAsync(trackChanges);
            var activitiesResponse = _mapper.Map<List<ActivityResponseModel>>(activities);
            return activitiesResponse;
        }

        public async Task<List<ActivityResponseModel>> GetAllActivitiesByUser(bool trackChanges, string userName)
        {
            var activities = await _repositoryManager.Activity.GetAllActivitiesWithUserAsync(trackChanges, userName);
            var response = _mapper.Map<List<ActivityResponseModel>>(activities);
            return response;
        }
        public async Task<ActivityResponseModel> GetOneActivityAsync(string userName, string activityName)
        {
            if (userName is null || activityName is null)
                throw new ArgumentNullException("user name or activity name is null");
            var activity = await _repositoryManager.Activity.GetOneActivityAsync(userName, activityName, false);
            if (activity is null)
                throw new ArgumentNullException();
            return _mapper.Map<ActivityResponseModel>(activity);
        }

        public async Task<ActivityResponseModel> GetOneActivityAsync(int id, bool trackChanges)
        {
            var activity = await _repositoryManager.Activity.GetOneActivityAsync(id, trackChanges);
            if (activity is null)
                throw new ArgumentNullException();
            return _mapper.Map<ActivityResponseModel>(activity);
        }


        public async Task<ActivityResponseModel> UpdateOneActivitiyAsync(ActivityUpdateRequestModel activity)
        {
            if (activity is null) throw new ArgumentNullException();
            var actv = await _repositoryManager.Activity.GetOneActivityAsync(activity.Id, true);
            actv.LastUpdatedAt= DateTime.UtcNow;
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ActivityResponseModel>(actv);
        }
    }
}
