using ActivityPlanner.Frontend.Models.Auth;

namespace ActivityPlanner.Frontend.Services.Contracts.Auth;

public interface IAuthApi
{
    Task<TokenResponse> LoginAsync(LoginRequest req, CancellationToken ct = default);
    Task<TokenResponse> RefreshAsync(RefreshRequest req, CancellationToken ct = default);
    Task<TokenResponse> RegisterAsync(RegisterRequest req, CancellationToken ct = default); // opsiyonel
}
