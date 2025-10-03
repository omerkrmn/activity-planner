using ActivityPlanner.Frontend.Services.Contracts;
using Microsoft.JSInterop;

namespace ActivityPlanner.Frontend.Services.Token
{
    public sealed class LocalStorageTokenStore(IJSRuntime js) : ITokenStore
    {
        const string Key = "jwt";

        public Task SetTokenAsync(string token) =>
            js.InvokeVoidAsync("localStorage.setItem", Key, token).AsTask();

        public Task<string?> GetTokenAsync() =>
            js.InvokeAsync<string?>("localStorage.getItem", Key).AsTask();

        public Task RemoveTokenAsync() =>
            js.InvokeVoidAsync("localStorage.removeItem", Key).AsTask();
    }
}
