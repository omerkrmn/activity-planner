using ActivityPlanner.Frontend.Models.Auth;
using ActivityPlanner.Frontend.Services.Contracts;
using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace ActivityPlanner.Frontend.Services.Token;

public class LocalStorageTokenStore : ITokenStore
{
    private readonly ILocalStorageService _localStorage;
    private const string Key = "auth_tokens";

    public LocalStorageTokenStore(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task SaveAsync(TokenPair pair, CancellationToken ct = default)
    {
        await _localStorage.SetItemAsync(Key, pair, ct);
    }

    public async Task<string?> GetAccessTokenAsync(CancellationToken ct = default)
    {
        var pair = await _localStorage.GetItemAsync<TokenPair>(Key, ct);
        return pair?.AccessToken;
    }

    public async Task<string?> GetRefreshTokenAsync(CancellationToken ct = default)
    {
        var pair = await _localStorage.GetItemAsync<TokenPair>(Key, ct);
        return pair?.RefreshToken;
    }

    public async Task<DateTimeOffset?> GetExpiryAsync(CancellationToken ct = default)
    {
        var pair = await _localStorage.GetItemAsync<TokenPair>(Key, ct);
        return pair?.ExpiresAtUtc;
    }

    public async Task ClearAsync(CancellationToken ct = default)
    {
        await _localStorage.RemoveItemAsync(Key, ct);
    }
}
