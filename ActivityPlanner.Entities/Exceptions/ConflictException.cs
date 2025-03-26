using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Entities.Exceptions
{
    public class ConflictException : Exception
    {
        public string ErrorCode { get; set; } = string.Empty;
        public DateTime Timestamp { get; } = DateTime.UtcNow;

        public ConflictException(string message) : base(message)
        {

        }
    }
}
