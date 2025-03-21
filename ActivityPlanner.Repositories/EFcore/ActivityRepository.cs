using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        // buradaki kod satırı değişebilir yerinin burası olup olmadığına emin değilim.
        // SubscriberService sınıfında bu tarz bir metoda ihtiyaç duydum aynı kodu 3 kere yazmak istemedim.
        // ya ActivityService'yi DI a ekleyip Serviceler arası bi bağımlılık oluşturacaktım ya da bu şekilde kullanacaktım.
        public async Task ChangeActivityAttendanceStatusCountAsync(int activityId, AttendanceStatus status)
        {
            var activity = await FindAll(true)
                .Where(a => a.Id.Equals(activityId))
                .SingleOrDefaultAsync();
            if (activity == null)
                throw new ArgumentNullException("activity is null");

            if (status == AttendanceStatus.Confirmed)
            {
                activity.AttendanceStatusConfirmedCount--;
                activity.AttendanceStatusUnsureCount++;
            }
            else
            {
                activity.AttendanceStatusConfirmedCount++;
                activity.AttendanceStatusUnsureCount--;
            }
        }

        public async Task<List<Activity>> GetAllActivitiesWithUserAsync(bool trackChanges, string userName)
        {
            return await
                FindAll(trackChanges)
                .Include(b => b.AppUser)
                .Where(a => a.AppUser.UserName.Equals(userName))
                .ToListAsync();
        }
        public async Task<Activity> GetOneActivityAsync(string userName, string activityName, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Where(b => b.AppUser.UserName.Equals(userName))
                .Include(b => b.AppUser)
                .Where(b => b.ActivityName.Equals(activityName))
                .SingleOrDefaultAsync();
        }

        public void CreateOneActivitiy(Activity activity) => Create(activity);

        public void DeleteOneActivitiy(Activity activity) => Delete(activity);

        public async Task<List<Activity>> GetAllActivitiesAsync(bool trackChanges)
        {

            return await
                FindAll(trackChanges)
                .OrderBy(a => a.Id)
                .ToListAsync();
        }

        public async Task<Activity> GetOneActivityAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateOneActivitiy(Activity activity) => Update(activity);


    }
}
