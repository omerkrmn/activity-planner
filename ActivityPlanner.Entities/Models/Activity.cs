using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.Models
{
    public class Activity
    {
        public int AppUserId {  get; set; }
        public AppUser AppUser { get; set; }

        public ICollection<Subscriber> Subscribers { get; set; }=new List<Subscriber>();
        public string ActivityName { get; set; }=string.Empty;
        public string ActivityDescription{ get; set; } = string.Empty;



    }
}
