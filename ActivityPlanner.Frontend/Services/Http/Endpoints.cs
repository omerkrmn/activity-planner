namespace ActivityPlanner.Frontend.Services.Http
{
    public static class Endpoints
    {
        public const string Activities = "activities";
        public static string ActivityById(int id) => $"activities/{id}";
    }
}
