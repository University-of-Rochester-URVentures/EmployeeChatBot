using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Models
{
    public class LoginViewModel
    {
        public bool FailedLogin { get; set; }

        public bool ValidationFailure { get; set; }

        public bool UnknownFailure { get; set; }
    }
}
