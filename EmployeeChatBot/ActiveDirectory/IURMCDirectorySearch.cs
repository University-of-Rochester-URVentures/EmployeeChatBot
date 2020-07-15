using System;
using System.Collections.Generic;
using System.Text;

namespace URMC.ActiveDirectory {
    public interface IURMCDirectorySearch: IDisposable {

        /// <summary>
        /// get user record for authenticated user
        /// </summary>
        /// <returns>full record</returns>
        ActiveDirectoryUser GetUser();
    }
}
