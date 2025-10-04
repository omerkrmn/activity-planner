using ActivityPlanner.Frontend.Models.Auth;

namespace ActivityPlanner.Frontend.Services.Contracts
{
    public interface ITokenStore
    {
        Task SaveAsync(TokenPair pair, CancellationToken ct = default);
        Task<string?> GetAccessTokenAsync(CancellationToken ct = default);
        Task<string?> GetRefreshTokenAsync(CancellationToken ct = default);
        Task<DateTimeOffset?> GetExpiryAsync(CancellationToken ct = default);
        Task ClearAsync(CancellationToken ct = default);
    }
}
