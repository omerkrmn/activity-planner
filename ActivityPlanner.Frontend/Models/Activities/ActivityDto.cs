namespace ActivityPlanner.Frontend.Models.Activities
{
    public sealed class ActivityDto
    {
        public int Id { get; set; }

        public Guid AppUserId { get; set; }

        public string ActivityName { get; set; } = string.Empty;

        public string ActivityDescription { get; set; } = string.Empty;

        public int AttendanceStatusConfirmedCount { get; set; }

        public int AttendanceStatusUnsureCount { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastRegistrationDate { get; set; }
    }
}
