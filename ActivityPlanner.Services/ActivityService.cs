using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ActivityService : IActivityService
    {
        //todo: dto ları burada kullanacaksın şuanlık bu şekilde kalsınlar daha sonra dtolara geç!
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public ActivityService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ActivityResponseModel> CreateOneActivitiyAsync(ActivityCreateRequestModel activity, string userId)
        {
            if (activity == null)
                throw new ArgumentNullException();
            var tempActivity = _mapper.Map<Activity>(activity);
            tempActivity.AppUserId = userId;

            _repositoryManager.Activity.CreateOneActivitiy(tempActivity);

            await _repositoryManager.SaveAsync();

            return _mapper.Map<ActivityResponseModel>(_mapper.Map<Activity>(tempActivity));
        }

        public async Task<ActivityResponseModel> DeleteOneActivitiyAsync(ActivityDeleteRequestModel activity, string userId)
        {
            if (activity is null)
                throw new ArgumentNullException();
            var check = await _repositoryManager.Activity.GetOneActivityAsync(activity.Id, true);

            if (check is null)
                throw new ArgumentNullException();

            check.AppUserId = userId;
            _repositoryManager.Activity.DeleteOneActivitiy(check);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<ActivityResponseModel>(check);

        }

        public async Task<List<ActivityResponseModel>> GetAllActivitiesAsync(bool trackChanges)
        {
            var activities = await _repositoryManager.Activity.GetAllActivitiesAsync(trackChanges);
            var activitiesResponse = _mapper.Map<List<ActivityResponseModel>>(activities);
            return activitiesResponse;
        }

        public async Task<List<ActivityResponseModel>> GetAllActivitiesByUser(bool trackChanges, string userName)
        {
            var activities = await _repositoryManager.Activity.GetAllActivitiesWithUserAsync(trackChanges,userName);
            var response = _mapper.Map<List<ActivityResponseModel>>(activities);
            return response;
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
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ActivityResponseModel>(actv);
        }
    }
}
