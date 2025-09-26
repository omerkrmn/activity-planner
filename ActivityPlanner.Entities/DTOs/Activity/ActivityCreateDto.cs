using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activites
{
    public class ActivityCreateDto
    {
        // User Id Claimden gelecek

        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime LastRegistrationDate { get; set; }
    }
}
