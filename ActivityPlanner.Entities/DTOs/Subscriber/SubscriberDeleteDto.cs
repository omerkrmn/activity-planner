    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.DTOs.Subscriber
{
    public class SubscriberDeleteDto 
    {
        // bu mail adresine bir abonelik iptali için mail gidecek eğer o maile tıklanırsa abonelik iptal edilecek
        [Required]  
        public int ActivityId { get; set; }
        [Required]
        [EmailAddress]
        public string SubscriberMail { get; set; } = string.Empty;
    }
}
