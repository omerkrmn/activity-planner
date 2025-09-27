﻿using ActivityPlanner.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Subscriber
{
    public class SubscriberResponseDto
    {
        public int SubscriberId { get; set; }
        public string SubscriberName { get; set; } = string.Empty;
        public string SubscriberSurname { get; set; } = string.Empty;
        [EmailAddress]
        public string SubscriberMail { get; set; } = string.Empty;
        public string MailValidation { get; set; } = string.Empty;
        public AttendanceStatus AttendanceStatus { get; set; }
        public string Note { get; set; } = string.Empty;

        public int ActivityId { get; set; }
    }
}
