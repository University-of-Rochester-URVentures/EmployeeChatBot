using EmployeeChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Data.Access.Abstraction
{
    public interface IReportAccess
    {
        Task SaveReport(int reportId, bool fever, bool coughing, bool breathing, bool soreThroat, bool bodyAches, bool lossOfSmell);

        Task<ReportDataModel> CheckReport(int reportId);

        Task<ReportDataModel> CreateReport(string username, int empId, string email);

        Task<ReportDataModel> CheckReportByEmployeeId(int empId);

        Task<ReportDataModel> CheckReportByEmail(string email);

        Task LogFailedLogin(string username, string domain);
    }
}
