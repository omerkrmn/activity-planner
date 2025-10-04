using ActivityPlanner.Frontend.Models.Auth;
using ActivityPlanner.Frontend.Options;
using ActivityPlanner.Frontend.Services.Contracts.Auth;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace ActivityPlanner.Frontend.Services.Auth;

public class AuthApi(HttpClient http, IOptions<AuthOptions> opts) : IAuthApi
{
    private readonly HttpClient _http = http;
    private readonly AuthOptions _o = opts.Value;

    public async Task<TokenResponse> LoginAsync(LoginRequest req, CancellationToken ct = default)
    {
        var res = await _http.PostAsJsonAsync(_o.LoginPath, req, ct);
        res.EnsureSuccessStatusCode();
        var dto = await res.Content.ReadFromJsonAsync<TokenResponse>(cancellationToken: ct);
        return dto ?? throw new InvalidOperationException("Login response boş.");
    }

    public async Task<TokenResponse> RefreshAsync(RefreshRequest req, CancellationToken ct = default)
    {
        // Eğer API Bearer ile eski access token’ı header’da da istiyorsa:
        // using var msg = new HttpRequestMessage(HttpMethod.Post, _o.RefreshPath) { Content = JsonContent.Create(req) };
        // msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", req.AccessToken);
        // var res = await _http.SendAsync(msg, ct);

        var res = await _http.PostAsJsonAsync(_o.RefreshPath, req, ct);
        res.EnsureSuccessStatusCode();
        var dto = await res.Content.ReadFromJsonAsync<TokenResponse>(cancellationToken: ct);
        return dto ?? throw new InvalidOperationException("Refresh response boş.");
    }

    //public async Task<CurrentUser> MeAsync(CancellationToken ct = default)
    //{
    //    var dto = await _http.GetFromJsonAsync<CurrentUser>(_o.MePath, ct);
    //    return dto ?? new CurrentUser();
    //}

    public async Task<TokenResponse> RegisterAsync(RegisterRequest req, CancellationToken ct = default)
    {
        var res = await _http.PostAsJsonAsync(_o.RegisterPath, req, ct);
        res.EnsureSuccessStatusCode();
        var dto = await res.Content.ReadFromJsonAsync<TokenResponse>(cancellationToken: ct);
        return dto ?? throw new InvalidOperationException("Register response boş.");
    }
}