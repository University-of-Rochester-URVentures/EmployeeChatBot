using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using EmployeeChatBot.Models;
using Novell.Directory.Ldap;
using Novell.Directory.Ldap.Utilclass;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using EmployeeChatBot.ActiveDirectory;

namespace URMC.ActiveDirectory {
    public class ActiveDirectorySearch : IActiveDirectorySearch {
        private LdapConnection ldapConnection;
        private ActiveDirectoryUser user;

        public ActiveDirectorySearch(Credentials credentials, string fulldomain, int port, string searchbase, Credentials _serviceUser)
        {
            user = new ActiveDirectoryUser();
            using (var context = new PrincipalContext(ContextType.Domain, fulldomain, _serviceUser.Username, _serviceUser.Password))
            {

                if (context.ValidateCredentials(credentials.Username, credentials.Password))
                {

                    using (UserPrincipal userP = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, credentials.Username))
                    {
                        if (userP == null)
                        {
                            //user authorized but does not actually have a record...
                            throw new UnauthorizedADAccessException("Active Directory record not found");
                        }

                        user.Mail = userP.EmailAddress;
                        user.Username = userP.SamAccountName;
                        using (DirectoryEntry de = userP.GetUnderlyingObject() as DirectoryEntry)
                        {
                            if (de != null)
                            {
                                if (de.Properties.Contains("department"))
                                    user.Department = de.Properties["department"].Value as string;
                                if (de.Properties.Contains("displayName"))
                                    user.DisplayName = de.Properties["displayName"].Value as string;
                                if (de.Properties.Contains("distinguishedName"))
                                    user.DistinguishedName = de.Properties["distinguishedName"].Value as string;
                                // We have a custom property in our AD that identifies the employee's unique identifier
                                // Change the property name below to whatever your AD property name is to save off this identifier
                                if (de.Properties.Contains("EmployeeIdentifier"))
                                    user.EmployeeId = de.Properties["EmployeeIdentifier"].Value as string;
                                
                            }
                        }
                    }
                }
                else
                {
                    //user could not be authenticated
                    throw new UnauthorizedADAccessException("Unauthorized to access ActiveDirectory");
                }
            }
        }

        public ActiveDirectoryUser GetUser()
        {
            return user;

        }

        public void Dispose() {
            ldapConnection?.Disconnect();
            ldapConnection?.Dispose();
            ldapConnection = null;
        }
    }
}
