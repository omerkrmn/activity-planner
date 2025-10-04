using ActivityPlanner.Frontend.Services.Contracts;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace ActivityPlanner.Frontend.Services.Http
{
    public sealed class ApiClient(HttpClient http, ITokenStore tokens)
    {
        static readonly JsonSerializerOptions JsonOpts = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task<T> GetAsync<T>(string url, CancellationToken ct = default)
        {
            using var req = await BuildRequest(HttpMethod.Get, url);
            using var resp = await http.SendAsync(req, ct);
            await EnsureSuccess(resp);
            return (await resp.Content.ReadFromJsonAsync<T>(JsonOpts, ct))!;
        }

        public async Task<TResult> PostAsync<TBody, TResult>(string url, TBody body, CancellationToken ct = default)
        {
            using var req = await BuildRequest(HttpMethod.Post, url, body);
            using var resp = await http.SendAsync(req, ct);
            await EnsureSuccess(resp);
            return (await resp.Content.ReadFromJsonAsync<TResult>(JsonOpts, ct))!;
        }

        public async Task DeleteAsync(string url, CancellationToken ct = default)
        {
            using var req = await BuildRequest(HttpMethod.Delete, url);
            using var resp = await http.SendAsync(req, ct);
            await EnsureSuccess(resp);
        }

        async Task<HttpRequestMessage> BuildRequest(HttpMethod method, string url, object? body = null)
        {
            var req = new HttpRequestMessage(method, url);
            var token = await tokens.GetAccessTokenAsync();
            if (!string.IsNullOrWhiteSpace(token))
                req.Headers.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            if (body is not null)
                req.Content = JsonContent.Create(body, options: JsonOpts);

            return req;
        }

        static async Task EnsureSuccess(HttpResponseMessage resp)
        {
            if (resp.IsSuccessStatusCode) return;

            var text = await resp.Content.ReadAsStringAsync();
            var msg = $"HTTP {(int)resp.StatusCode} {resp.ReasonPhrase}: {text}";

            if (resp.StatusCode is HttpStatusCode.Unauthorized or HttpStatusCode.Forbidden)
                throw new UnauthorizedAccessException(msg);

            throw new HttpRequestException(msg);
        }
    }
}
