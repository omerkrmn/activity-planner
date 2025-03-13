using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; }
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    }
}
