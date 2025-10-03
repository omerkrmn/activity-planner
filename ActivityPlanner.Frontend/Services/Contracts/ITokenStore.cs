namespace ActivityPlanner.Frontend.Services.Contracts
{
    public interface ITokenStore
    {
        Task SetTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task RemoveTokenAsync();
    }
}
