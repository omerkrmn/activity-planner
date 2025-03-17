using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface IActivityService
    {
        Task<List<ActivityResponseModel>> GetAllActivitiesAsync(bool trackChanges);

        Task<ActivityResponseModel> GetOneActivityAsync(int id, bool trackChanges);
        Task<ActivityResponseModel> GetOneActivityAsync(string userName,string activityName);

        Task<ActivityResponseModel> CreateOneActivitiyAsync(ActivityCreateRequestModel activity, string userId);
        Task<ActivityResponseModel> UpdateOneActivitiyAsync(ActivityUpdateRequestModel activity);
        Task<ActivityResponseModel> DeleteOneActivitiyAsync(ActivityDeleteRequestModel activity, string userId);

        Task<List<ActivityResponseModel>> GetAllActivitiesByUser(bool trackChanges, string userName);

    }
}
