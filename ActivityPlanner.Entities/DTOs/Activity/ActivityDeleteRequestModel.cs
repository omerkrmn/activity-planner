using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activites
{
    public class ActivityDeleteRequestModel
    {
        public Guid Id { get; set; }
        public Guid AppUserId { get; set; }
        
    }
}
