using EmployeeChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Data.Access.Abstraction
{
    public interface IReportAccess
    {
        Task SaveReport(int reportId, bool fever, bool coughing, bool breathing, bool soreThroat, bool bodyAches, bool allergies, bool lossOfSmell);

        Task<ReportDataModel> CheckReport(int reportId);

        Task<ReportDataModel> CreateReport(string username, int urId, string email);

        Task<ReportDataModel> CheckReportByUrId(int urId);

        Task<IList<StudentDataModel>> GetStudents();

        Task<ReportDataModel> CheckReportByEmail(string email);

        Task LogFailedLogin(string username, string domain);
    }
}
