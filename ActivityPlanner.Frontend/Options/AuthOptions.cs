namespace ActivityPlanner.Frontend.Options
{
    // Options/AuthOptions.cs
    public class AuthOptions
    {
        public const string SectionName = "Auth";
        public string BaseUrl { get; set; } = "";           
        public string LoginPath { get; set; } = "/api/authentication/login";
        public string RefreshPath { get; set; } = "/api/authentication/refresh";
        public string RegisterPath { get; set; } = "/api/authentication/";
    }

}
