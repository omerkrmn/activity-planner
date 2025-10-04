using ActivityPlanner.Frontend.Models.Auth;

namespace ActivityPlanner.Frontend.Services.Contracts.Auth;

public interface IAuthService
{
    Task<bool> LoginAsync(LoginRequest req, CancellationToken ct = default);
    Task LogoutAsync(CancellationToken ct = default);
    Task<bool> TryRefreshAsync(CancellationToken ct = default);
    //Task<CurrentUser?> GetCurrentUserAsync(CancellationToken ct = default);
}