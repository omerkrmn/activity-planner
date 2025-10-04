namespace ActivityPlanner.Frontend.Models.Auth
{
    public record TokenPair(string AccessToken, string RefreshToken, DateTimeOffset ExpiresAtUtc);
}
