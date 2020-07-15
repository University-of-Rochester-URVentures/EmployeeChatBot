using System;
using System.Collections.Generic;
using System.Text;

namespace URMC.ActiveDirectory {
    public class ActiveDirectoryUser {
        public string Username { get; set; }
        public string Phone { get; set; }

        public IList<String> MemberOf { get; set; }

        public string Department { get; set; }

        public string DisplayName { get; set; }

        public string DistinguishedName { get; set; }

        public string Mail { get; set; }

        public string EmployeeId { get; set; }
    }
}
