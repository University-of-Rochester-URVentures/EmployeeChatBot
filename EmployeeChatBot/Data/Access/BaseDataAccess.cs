using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeChatBot.Data.Access
{
    public class BaseDataAccess
    {
        private readonly string dbConnString;

        public BaseDataAccess(IConfiguration config)
        {
            dbConnString = config["Database:ConnectionString"];
        }

        protected IDbConnection DbConnection
        {
            get
            {
                return new SqlConnection(dbConnString);
            }
        }
    }
}
