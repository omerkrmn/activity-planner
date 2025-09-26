using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.RequestFeatures
{
    public class ActivityParameters : RequestParameters
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime? Date { get; set; }
    }
}
