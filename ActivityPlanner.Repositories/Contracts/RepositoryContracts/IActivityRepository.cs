using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.Contracts.RepositoryContracts
{
    public interface IActivityRepository : IRepositoryBase<Activity>
    {
        Task<List<Activity>> GetAllActivitiesAsync(bool trackChanges);
        Task<Activity> GetOneActivityAsync(int id, bool trackChanges);
        Task<List<Activity>> GetAllActivitiesWithUserAsync(bool trackChanges, string userName);
        void CreateOneActivitiy(Activity activity);
        void UpdateOneActivitiy(Activity activity);
        void DeleteOneActivitiy(Activity activity);
    }
}
