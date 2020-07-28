using EmployeeChatBot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace URMC.ActiveDirectory {
    public interface IActiveDirectory {
        /// <summary>
        /// for bulk lookups use the returned object that does the same but keeps LDAP connection open
        /// </summary>
        /// <param name="credentials">credentials to connect to LDAP, null to use default credentials</param>
        /// <returns></returns>
        IActiveDirectorySearch DirectorySearch(Credentials credentials = null);

        /// <summary>
        /// find user record using username
        /// </summary>
        /// <param name="username">username (no domain names included in any way)</param>
        /// <param name="password">complementing password to use to access LDAP (null to use default credentials for access)</param>
        /// <returns>full user record for the username</returns>
        /// 
        ActiveDirectoryUser GetUserByUsername(string username, string password = null);
    }
}
