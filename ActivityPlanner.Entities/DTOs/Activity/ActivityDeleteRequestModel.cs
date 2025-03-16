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
        public int Id { get; set; }
        public int AppUserId { get; set; }
        
    }
}
