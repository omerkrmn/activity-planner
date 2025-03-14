using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface IActivityService
    {
        Task<List<Activity>> GetAllActivitiesAsync(bool trackChanges);
        Task<Activity> GetOneActivityAsync(int id, bool trackChanges);
        void CreateOneActivitiy(Activity activity);
        void UpdateOneActivitiy(Activity activity);
        void DeleteOneActivitiy(Activity activity);
    }
}
