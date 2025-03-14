using ActivityPlanner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.Models
{
    public class Subscriber 
    {
        public Guid SubscriberId { get; set; }= Guid.NewGuid();
        public string SubscriberName { get; set; } = string.Empty;
        public string SubscriberSurname { get; set; } = string.Empty;
        [EmailAddress]
        public string SubscriberMail { get; set; } = string.Empty;
        public string MailValidation { get; set; } = string.Empty;
        public AttendanceStatus AttendanceStatus { get; set; } = AttendanceStatus.Confirmed;

        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; }

    }
}
