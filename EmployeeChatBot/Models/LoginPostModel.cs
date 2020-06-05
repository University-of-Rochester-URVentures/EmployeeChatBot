using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Models
{
    public class LoginPostModel
    {
        public string mail { get; set; }

        public bool showPositive { get; set; }

        public bool showNegative { get; set; }

        public string reportedOn { get; set; }
    }
}
