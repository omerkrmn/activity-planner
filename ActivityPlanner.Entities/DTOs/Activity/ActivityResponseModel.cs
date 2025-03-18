using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activity
{
    //buna çokta gerek olmayabilir.
    public class ActivityResponseModel
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } =string.Empty;

        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public int AttendanceStatusConfirmedCount { get; set; } = 0;
        public int AttendanceStatusUnsureCount { get; set; } = 0;
    }
}
