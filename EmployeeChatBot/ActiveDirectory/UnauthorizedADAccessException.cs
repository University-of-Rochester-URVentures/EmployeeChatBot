using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.ActiveDirectory
{
    public class UnauthorizedADAccessException : Exception
    {
        public UnauthorizedADAccessException(string message) : base(message)
        {
            
        }
    }
}
