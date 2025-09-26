using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Subscriber
{
    public class SubscriberWithActivityDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } = string.Empty;

        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public IEnumerable<SubscriberResponseDto> Subscribers { get; set; }
    }
}
