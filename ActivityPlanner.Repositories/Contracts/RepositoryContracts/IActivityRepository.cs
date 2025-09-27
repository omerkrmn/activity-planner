using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.Contracts.RepositoryContracts
{
    public interface IActivityRepository : IRepositoryBase<Activity>
    {

        Task<IReadOnlyList<Activity>> GetAllAsync(
            ActivityParameters parameters,
            bool trackChanges,
            CancellationToken ct = default);

        Task<IReadOnlyList<Activity>> GetAllByUserAsync(
            string userId,
            ActivityParameters parameters,
            bool trackChanges,
            CancellationToken ct = default);

        Task<Activity?> GetByIdAsync(
            int id,
            bool trackChanges,
            CancellationToken ct = default);

        Task<Activity?> GetByIdForUserAsync(
            int activityId,
            string userId,
            bool trackChanges,
            CancellationToken ct = default);

        Task ChangeAttendanceStatusCountAsync(
            int activityId,
            AttendanceStatus status,
            CancellationToken ct = default);

        Task<int> GetTotalCountAsync(ActivityParameters parameters, CancellationToken ct = default);
        Task IncrementAttendanceStatusCountAsync(int activityId,AttendanceStatus status,CancellationToken ct = default);
    }
}
