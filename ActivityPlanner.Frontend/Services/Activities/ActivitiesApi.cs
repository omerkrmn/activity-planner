using ActivityPlanner.Frontend.Models.Activities;
using ActivityPlanner.Frontend.Services.Contracts;
using ActivityPlanner.Frontend.Services.Http;
using ActivityPlanner.Frontend.Utils;

namespace ActivityPlanner.Frontend.Services.Activities
{
    public sealed class ActivitiesApi(ApiClient api) : IActivitiesApi
    {
        public Task<List<ActivityDto>> GetListAsync(ActivityFilterModel f, CancellationToken ct = default)
        {
            var url = QueryStringBuilder.Add(Endpoints.Activities, new Dictionary<string, string?>
            {
                ["country"] = f.Country,
                ["city"] = f.City,
                ["date"] = f.DateString
                // Şimdilik pageNumber/pageSize YOK
            });

            return api.GetAsync<List<ActivityDto>>(url, ct);
        }

        public Task<ActivityDto> GetByIdAsync(int id, CancellationToken ct = default)
            => api.GetAsync<ActivityDto>(Endpoints.ActivityById(id), ct);
    }
}
