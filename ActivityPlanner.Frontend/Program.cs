using ActivityPlanner.Frontend;
using ActivityPlanner.Frontend.Options;
using ActivityPlanner.Frontend.Services.Activities;
using ActivityPlanner.Frontend.Services.Contracts;
using ActivityPlanner.Frontend.Services.Http;
using ActivityPlanner.Frontend.Services.Token;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.Configure<ApiOptions>(cnf =>
    builder.Configuration.GetSection(nameof(ApiOptions)));



builder.Services.AddScoped<ITokenStore, LocalStorageTokenStore>();

builder.Services.AddScoped(sp =>
{
    var opts = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
    return new HttpClient
    {
        BaseAddress = new Uri(opts.BaseUrl.TrimEnd('/') + "/"),
        Timeout = TimeSpan.FromSeconds(20)
    };
});
builder.Services.AddScoped<ApiClient>();
builder.Services.AddScoped<IActivitiesApi, ActivitiesApi>();

await builder.Build().RunAsync();
