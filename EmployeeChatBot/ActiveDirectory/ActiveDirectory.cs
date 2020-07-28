using System;
using System.IO;
using System.Threading.Tasks;
using EmployeeChatBot.Models;

namespace URMC.ActiveDirectory {
    public class ActiveDirectory: IActiveDirectory {
        private readonly string _fulldomain;
        private readonly int _port;
        private readonly string _searchBase;
        private readonly Credentials _serviceUser;

        public ActiveDirectory(string fulldomain, int port, string searchBase, string username, string password)
        {
            _fulldomain = fulldomain; _port = port; _searchBase = searchBase;
            if (!String.IsNullOrWhiteSpace(username) && password != null)
            {
                _serviceUser = new Credentials() { Username = username, Password = password };
            }
            else _serviceUser = null;
        }

        public IActiveDirectorySearch DirectorySearch(Credentials credentials = null)
        {
            Credentials _credentials = credentials ?? _serviceUser;
            if (_credentials == null) throw new UnauthorizedAccessException();
            return new ActiveDirectorySearch(_credentials, _fulldomain, _port, _searchBase, _serviceUser ?? credentials);
        }

        public ActiveDirectoryUser GetUserByUsername(string username, string password = null)
        {
            Credentials credentials = password == null ? null : new Credentials() { Username = username, Password = password };
            using (var search = DirectorySearch(credentials))
            {
                return search.GetUser();
            }
        }

        public Task<ActiveDirectoryUser> AuthenticateAsync(Credentials loginModel)
        {
            return Task<ActiveDirectoryUser>.Run<ActiveDirectoryUser>(() => GetUserByUsername(loginModel.Username, loginModel.Password));
        }
    }
}
