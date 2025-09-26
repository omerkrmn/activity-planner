using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int AttendanceStatusConfirmedCount { get; set; } = 0;
        public int AttendanceStatusUnsureCount { get; set; } = 0;

        public ICollection<Subscriber> Subscribers { get; set; } = new List<Subscriber>();
        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        public DateTime LastRegistrationDate { get; set; }
        public bool IsActive => LastRegistrationDate.Date >= DateTime.UtcNow.Date;

        public string Country { get; set; } = string.Empty; 
        public string City { get; set; } = string.Empty;
        public string ActivityFullAddress { get; set; } = string.Empty;
    }
}
