using ActivityPlanner.Frontend.Models.Activities;

namespace ActivityPlanner.Frontend.Services.Contracts
{
    public interface IActivitiesApi
    {
        Task<List<ActivityDto>> GetListAsync(ActivityFilterModel filter, CancellationToken ct = default);
        Task<ActivityDto> GetByIdAsync(int id, CancellationToken ct = default);
    }
}
