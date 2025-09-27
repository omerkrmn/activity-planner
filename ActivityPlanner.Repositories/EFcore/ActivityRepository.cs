using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Exceptions;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Entities.RequestFeatures;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Repositories.Contracts.RepositoryContracts;
using ActivityPlanner.Repositories.EFcore.Extensions;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IReadOnlyList<Activity>> GetAllAsync(ActivityParameters parameters, bool trackChanges, CancellationToken ct = default)
        {
            return await FindAll(trackChanges)
                        .CheckStatus()
                        .CheckCountry(parameters.Country)
                        .CheckCity(parameters.City)
                        .CheckDate(parameters.Date)
                        .OrderBy(a => a.Id)
                        .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                        .Take(parameters.PageSize)
                        .ToListAsync(ct);
        }

        public async Task<IReadOnlyList<Activity>> GetAllByUserAsync(string userId, ActivityParameters parameters, bool trackChanges, CancellationToken ct = default)
        {
            return await FindByCondition(a => a.AppUserId == userId, trackChanges)
                        .CheckStatus()
                        .CheckCountry(parameters.Country)
                        .CheckCity(parameters.City)
                        .CheckDate(parameters.Date)
                        .OrderBy(a => a.Id)
                        .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                        .Take(parameters.PageSize)
                        .ToListAsync(ct);
        }

        public async Task<Activity?> GetByIdAsync(int id, bool trackChanges, CancellationToken ct = default)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                        .SingleOrDefaultAsync(ct)
                        .ConfigureAwait(false);
        }

        public async Task<Activity?> GetByIdForUserAsync(int activityId, string userId, bool trackChanges, CancellationToken ct = default)
        {
            return await FindByCondition(a => a.Id == activityId && a.AppUserId == userId, trackChanges)
                        .Include(a => a.AppUser)
                        .OrderBy(a => a.Id)
                        .FirstOrDefaultAsync(ct);
        }

        public async Task<int> GetTotalCountAsync(ActivityParameters parameters, CancellationToken ct = default)
        {
            return await FindAll(false)
                        .CheckStatus()
                        .CheckCountry(parameters.Country)
                        .CheckCity(parameters.City)
                        .CheckDate(parameters.Date)
                        .CountAsync(ct);
        }
        public async Task IncrementAttendanceStatusCountAsync(int activityId, AttendanceStatus status, CancellationToken ct = default)
        {
            var entity = await FindByCondition(a => a.Id == activityId, true)
                .FirstOrDefaultAsync(ct);
            
            if (entity == null)
                throw new NotFoundException("Activity not found.");
            
            if (status == AttendanceStatus.Confirmed)
                entity.AttendanceStatusConfirmedCount++;

            else if (status == AttendanceStatus.Unsure)
                entity.AttendanceStatusUnsureCount++;
        }
        public async Task ChangeAttendanceStatusCountAsync(int activityId, AttendanceStatus status, CancellationToken ct = default)
        {
            var activity = await
                         FindAll(true)
                        .Where(a => a.Id.Equals(activityId))
                        .SingleOrDefaultAsync(ct);
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
    }
}
