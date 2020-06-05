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

        public async Task SaveReport(int reportId, bool fever, bool coughing, bool breathing, bool soreThroat, bool bodyAches, bool allergies, bool lossOfSmell)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            await
                conn.ExecuteAsync(
                    "[dbo].[Report_Save5]",
                    new
                    {
                        ReportId = reportId,
                        Fever = fever,
                        Breathing = breathing,
                        Coughing = coughing,
                        SoreThroat = soreThroat,
                        BodyAches = bodyAches,
                        LossOfSmell = lossOfSmell,
                        Allergies = allergies
                    },
                    commandType: CommandType.StoredProcedure);
        }

        public async Task<IList<StudentDataModel>> GetStudents()
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var results = await conn.QueryAsync<StudentDataModel>("[dbo].[Student_GetAll]", null, commandType: CommandType.StoredProcedure);

            return
                results.ToList();
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

        public async Task<ReportDataModel> CreateReport(string username, int urId, string email)
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
                        UrId = urId,
                    },
                    commandType: CommandType.StoredProcedure);

            return retVal;
        }

        public async Task<ReportDataModel> CheckReportByUrId(int urId)
        {
            using IDbConnection conn = DbConnection;
            conn.Open();

            var reports = await
                conn.QueryFirstOrDefaultAsync<ReportDataModel>(
                    "[dbo].[Report_CheckByurId]",
                    new
                    {
                        UrId = urId
                    },
                    commandType: CommandType.StoredProcedure);

            return
                reports;
        }

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