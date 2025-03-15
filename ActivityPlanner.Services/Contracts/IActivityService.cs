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
        Task<ActivityResponseModel> GetOneActivityAsync(Guid id, bool trackChanges);
        Task<ActivityResponseModel> CreateOneActivitiyAsync(ActivityCreateRequestModel activity);
        Task<ActivityResponseModel> UpdateOneActivitiyAsync(ActivityUpdateRequestModel activity);
        Task<ActivityResponseModel> DeleteOneActivitiyAsync(ActivityDeleteRequestModel activity);
        
    }
}
