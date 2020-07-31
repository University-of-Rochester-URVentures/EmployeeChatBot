using Dapper;
using Dapper.FluentMap;
using EmployeeChatBot.Data.Access.Abstraction;
using EmployeeChatBot.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Data.Access
{
    public class ReportAccess : BaseDataAccess, IReportAccess
    {
        public ReportAccess(IConfiguration config) : base(config)
        {
        }

        public async Task SaveReport(int reportId, bool fever, bool coughing, bool breathing, bool soreThroat, bool bodyAches, bool lossOfSmell)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            await
                conn.ExecuteAsync(
                    "[dbo].[Report_Save]",
                    new
                    {
                        ReportId = reportId,
                        Fever = fever,
                        Breathing = breathing,
                        Coughing = coughing,
                        SoreThroat = soreThroat,
                        BodyAches = bodyAches,
                        LossOfSmell = lossOfSmell
                    },
                    commandType: CommandType.StoredProcedure);
        }

        public async Task<ReportDataModel> CheckReportByEmail(string email)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var val = await
                conn.QueryFirstOrDefaultAsync<ReportDataModel>(
                    "[dbo].[Report_CheckByEmail]",
                    new
                    {
                        Email = email
                    },
                    commandType: CommandType.StoredProcedure);

            return val;
        }

        public async Task<ReportDataModel> CreateReport(string username, int empId, string email)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var retVal = await
                conn.QueryFirstOrDefaultAsync<ReportDataModel>(
                    "[dbo].[Report_Create]",
                    new
                    {
                        Username = username,
                        Email = email,
                        EmployeeId = empId,
                    },
                    commandType: CommandType.StoredProcedure);

            return retVal;
        }

        public async Task<ReportDataModel> CheckReportByEmployeeId(int empId)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var reports = await
                conn.QueryFirstOrDefaultAsync<ReportDataModel>(
                    "[dbo].[Report_CheckByEmployeeId]",
                    new
                    {
                        EmployeeId = empId
                    },
                    commandType: CommandType.StoredProcedure);

            return
                reports;
        }

        // This is an optional table that we utilized in order to track individuals who had login failures.
        // We would follow up with them to ensure their accounts were setup properly and they could take the chatbot daily
        // The Domain indicated the issue with the account and what account they had (UR vs URMC Active Directory in our case)
        // Username was the username they attempted to use.
        public async Task LogFailedLogin(string username, string domain)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            await
                conn.ExecuteAsync(
                    "[dbo].[FailedLogin_Save]",
                    new
                    {
                        Domain = domain,
                        Username = username
                    },
                    commandType: CommandType.StoredProcedure);
        }

        public async Task<ReportDataModel> CheckReport(int reportId)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var retVal = await
                conn.QueryFirstOrDefaultAsync<ReportDataModel>(
                    "[dbo].[Report_CheckById]",
                    new
                    {
                        ReportId = reportId
                    },
                    commandType: CommandType.StoredProcedure);

            return retVal;
        }
    }
}