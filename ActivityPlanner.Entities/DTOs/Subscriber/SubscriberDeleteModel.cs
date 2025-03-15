using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Subscriber
{
    public class SubscriberDeleteModel 
    {
        [Required]  
        public Guid ActivityId { get; set; }
        [Required]
        [EmailAddress]
        public string SubscriberMail { get; set; } = string.Empty;
    }
}
