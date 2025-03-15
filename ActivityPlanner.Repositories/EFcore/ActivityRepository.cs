using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.EFcore
{
    public class ActivityRepository : RepositoryBase<Activity>, IActivityRepository
    {
        public ActivityRepository(RepositoryContext context) : base(context)
        {

        }
        //some other functions

        public void CreateOneActivitiy(Activity activity) => Create(activity);

        public void DeleteOneActivitiy(Activity activity) => Delete(activity);

        public async Task<List<Activity>> GetAllActivitiesAsync(bool trackChanges)
        {
            return await
                FindAll(trackChanges)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Activity> GetOneActivityAsync(int id, bool trackChanges) => await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneActivitiy(Activity activity) => Update(activity);
    }
}
