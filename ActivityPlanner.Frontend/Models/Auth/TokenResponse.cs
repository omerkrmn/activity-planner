namespace ActivityPlanner.Frontend.Models.Auth;
public record TokenResponse(string AccessToken, string RefreshToken, int ExpiresInSeconds);

