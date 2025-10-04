using ActivityPlanner.Frontend.Models.Auth;
using ActivityPlanner.Frontend.Services.Contracts;
using ActivityPlanner.Frontend.Services.Contracts.Auth;
using Microsoft.AspNetCore.Components.Authorization;

namespace ActivityPlanner.Frontend.Services.Auth;

public class AuthService(IAuthApi api, ITokenStore tokenStore, AuthenticationStateProvider authState) : IAuthService
{
    private readonly AuthStateProvider _state = (AuthStateProvider)authState;

    public async Task<bool> LoginAsync(LoginRequest req, CancellationToken ct = default)
    {
        var res = await api.LoginAsync(req, ct);
        var pair = new TokenPair(res.AccessToken, res.RefreshToken, DateTimeOffset.UtcNow.AddSeconds(res.ExpiresInSeconds));
        await tokenStore.SaveAsync(pair, ct);
        await _state.MarkUserAuthenticatedAsync(res.AccessToken);
        return true;
    }

    public async Task LogoutAsync(CancellationToken ct = default)
    {
        await tokenStore.ClearAsync(ct);
        await _state.MarkUserLoggedOutAsync();
    }

    public async Task<bool> TryRefreshAsync(CancellationToken ct = default)
    {
        var access = await tokenStore.GetAccessTokenAsync(ct);
        var refresh = await tokenStore.GetRefreshTokenAsync(ct);

        if (string.IsNullOrWhiteSpace(access) || string.IsNullOrWhiteSpace(refresh))
            return false;

        try
        {
            var res = await api.RefreshAsync(new RefreshRequest(access, refresh), ct);

            var pair = new TokenPair(
                res.AccessToken,
                res.RefreshToken,
                DateTimeOffset.UtcNow.AddSeconds(res.ExpiresInSeconds)
            );

            await tokenStore.SaveAsync(pair, ct);
            await _state.MarkUserAuthenticatedAsync(res.AccessToken);
            return true;
        }
        catch
        {
            // refresh de başarısızsa temizle (opsiyonel)
            // await tokenStore.ClearAsync(ct);
            return false;
        }
    }

    //public Task<CurrentUser?> GetCurrentUserAsync(CancellationToken ct = default) => api.MeAsync(ct);
}