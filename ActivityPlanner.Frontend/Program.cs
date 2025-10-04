using ActivityPlanner.Frontend;
using ActivityPlanner.Frontend.Options;
using ActivityPlanner.Frontend.Services.Activities;
using ActivityPlanner.Frontend.Services.Auth;
using ActivityPlanner.Frontend.Services.Contracts;
using ActivityPlanner.Frontend.Services.Contracts.Auth;
using ActivityPlanner.Frontend.Services.Http;
using ActivityPlanner.Frontend.Services.Token;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 1) Paket servisleri
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

// 2) Options (DOÐRU baðlama)
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(AuthOptions.SectionName));
builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(nameof(ApiOptions)));

// 3) Auth state + token store
builder.Services.AddScoped<ITokenStore, LocalStorageTokenStore>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

// 4) HTTP CLIENT’LAR

// 4.a) AuthApi için YALIN client (Authorization header yok, handler yok)
builder.Services.AddHttpClient<IAuthApi, AuthApi>((sp, client) =>
{
    var o = sp.GetRequiredService<IOptions<AuthOptions>>().Value;
    if (string.IsNullOrWhiteSpace(o.BaseUrl))
        throw new InvalidOperationException("AuthOptions.BaseUrl boþ! wwwroot/appsettings.json içindeki Auth.BaseUrl’i doldur.");

    client.BaseAddress = new Uri(o.BaseUrl.TrimEnd('/') + "/");
});

// 4.b) Protected API için named client + handler zinciri
builder.Services.AddTransient<AuthHeaderHandler>();
builder.Services.AddTransient<RefreshTokenHandler>();

builder.Services.AddHttpClient("ApiProtected", (sp, client) =>
{
    var api = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
    var baseUrl = api.BaseUrl;
    if (string.IsNullOrWhiteSpace(baseUrl))
        throw new InvalidOperationException("ApiOptions.BaseUrl boþ! wwwroot/appsettings.json içindeki ApiOptions.BaseUrl’i doldur.");

    client.BaseAddress = new Uri(baseUrl.TrimEnd('/') + "/");
    client.Timeout = TimeSpan.FromSeconds(20);
})
.AddHttpMessageHandler<AuthHeaderHandler>();
// 4.c) ApiClient ve ActivitiesApi: factory üzerinden named client kullan
builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("ApiProtected");
});
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<IActivitiesApi, ActivitiesApi>();

await builder.Build().RunAsync();
