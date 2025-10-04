namespace ActivityPlanner.Frontend.Models.Auth
{
    public class CurrentUser
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public IReadOnlyCollection<string> Roles { get; set; } = Array.Empty<string>();
    }
}
