using ActivityPlanner.Frontend.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ActivityPlanner.Frontend.Services.Auth;

public class AuthStateProvider(ITokenStore tokenStore) : AuthenticationStateProvider
{
    private static readonly ClaimsPrincipal _anon = new(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await tokenStore.GetAccessTokenAsync();
        if (string.IsNullOrWhiteSpace(token)) return new AuthenticationState(_anon);

        var identity = BuildIdentity(token);
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public Task MarkUserAuthenticatedAsync(string accessToken)
    {
        var identity = BuildIdentity(accessToken);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        return Task.CompletedTask;
    }

    public Task MarkUserLoggedOutAsync()
    {
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        return Task.CompletedTask;
    }

    private static ClaimsIdentity BuildIdentity(string jwt)
    {
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwt);
        var claims = token.Claims.ToList();
        return new ClaimsIdentity(claims, authenticationType: "jwt");
    }
}

