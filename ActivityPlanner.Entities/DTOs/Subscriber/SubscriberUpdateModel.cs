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
    public class SubscriberUpdateModel
    {
        public Guid SubscriberId { get; set; }

        [EmailAddress]
        public AttendanceStatus AttendanceStatus { get; set; }

        public Guid ActivityId { get; set; }
    }
}
