using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activity
{
    public class ActivityResponseModel
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }

        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public string shortLink { get; set; } = string.Empty;
    }
}
