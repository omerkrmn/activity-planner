namespace ActivityPlanner.Frontend.Models.Activities
{
    public sealed class ActivityFilterModel
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? DateString { get; set; } // yyyy-MM-dd
    }
}
