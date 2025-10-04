using ActivityPlanner.Frontend.Services.Contracts;
using System.Net.Http.Headers;

namespace ActivityPlanner.Frontend.Services.Http
{
    public class AuthHeaderHandler(ITokenStore tokenStore) : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
        {
            var token = await tokenStore.GetAccessTokenAsync(ct);
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return await base.SendAsync(request, ct);
        }
    }
}
    