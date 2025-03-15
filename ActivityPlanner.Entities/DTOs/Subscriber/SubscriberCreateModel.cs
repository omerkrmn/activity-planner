using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Subscriber
{
    public class SubscriberCreateModel 
    {
        [Required]
        public string SubscriberName { get; set; } = string.Empty;
        [Required]
        public string SubscriberSurname { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string SubscriberMail { get; set; } = string.Empty;
        public string MailValidation { get; set; } = string.Empty;
        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Confirmed;
        public int ActivityId { get; set; }
    }
}
