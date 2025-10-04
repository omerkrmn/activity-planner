using System.ComponentModel.DataAnnotations;

namespace ActivityPlanner.Frontend.Models.Activities
{
    public class ActivityCreateRequest
    {
        [Required]
        public string ActivityName { get; set; } = string.Empty;
        [Required]
        public string ActivityDescription { get; set; } = string.Empty;
        [Required]
        public DateTime LastRegistrationDate { get; set; }
        [Required, StringLength(60)]
        public string Country { get; set; } = string.Empty;

        [Required, StringLength(60)]
        public string City { get; set; } = string.Empty;
    }
}
