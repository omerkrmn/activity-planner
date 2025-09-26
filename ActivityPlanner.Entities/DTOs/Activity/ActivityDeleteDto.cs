using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Activites
{
    public class ActivityDeleteDto
    {
        // user id zaten claimlerden alınıyor activity id yeterli
        // buradaki id ilgili activity'nin id'si
        public int Id { get; set; }
    }
}
