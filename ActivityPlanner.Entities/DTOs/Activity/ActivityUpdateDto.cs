using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activites
{
    public class ActivityUpdateDto 
    {
        // user'ın idsi claimlerden alınıyor
        // buradaki id activity'nin id'si
        public int Id { get; set; } 
        public string ActivityName { get; set; } = string.Empty;
        public string ActivityDescription { get; set; } = string.Empty;
        public DateTime LastRegistrationDate { get; set; }
    }
}
