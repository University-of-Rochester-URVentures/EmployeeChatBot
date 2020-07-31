using EmployeeChatBot.ActiveDirectory;
using EmployeeChatBot.Data.Access.Abstraction;
using EmployeeChatBot.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using URMC.ActiveDirectory;

namespace EmployeeChatBot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReportAccess _reportAccess;

        public HomeController(IReportAccess reportAccess)
        {
            _reportAccess = reportAccess;
        }

        public async Task<IActionResult> SaveReport(ReportModel model)
        {
            if (model.Symptoms == null)
                model.Symptoms = "";

            if (model.ReportId == null)
                return Forbid();

            int reportId = Convert.ToInt32(model.ReportId);
            var reportCheck = await _reportAccess.CheckReport(reportId);
            if (reportCheck.CompletedAt != null)
            {
                return Forbid();
            }

            var coughing = model.Symptoms.Contains("Cough");
            var fever = model.Symptoms.Contains("Temperature");
            var breathing = model.Symptoms.Contains("Breathing");
            var soreThroat = model.Symptoms.Contains("Sore Throat");
            var bodyAches = model.Symptoms.Contains("Body Aches");
            var lossOfSmell = model.Symptoms.Contains("Loss of taste or smell");
            await _reportAccess.SaveReport(reportId, fever,
                coughing, breathing, soreThroat,
                bodyAches, lossOfSmell);

            return Ok();
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            //Login Logic here
            ActiveDirectoryUser user = null;
            IndexViewModel toRet = new IndexViewModel();
            // Login here!
            URMC.ActiveDirectory.ActiveDirectory directory = new URMC.ActiveDirectory.ActiveDirectory("URL", 636, "DirectoryClasses", "ServiceAccountName", "ServiceAccountPassword");
            try
            {
                user = directory.AuthenticateAsync(new Credentials() { Username = model.Username, Password = model.Password }).GetAwaiter().GetResult();
            }
            catch (UnauthorizedADAccessException)
            {
                LoginViewModel errorModel = new LoginViewModel();
                errorModel.FailedLogin = true;
                return View(errorModel);

            }

            // At this point you can optionally choose to check if the user has a report for the day by looking up their report by EmployeeId
            // You can then set the HasReport flag on the VM to display the previous report for the day

            ReportDataModel newReport = await _reportAccess.CreateReport(user.Username, Convert.ToInt32(user.EmployeeId), user.Mail);

            IndexViewModel indexViewModel = new IndexViewModel
            {
                ReportId = newReport.Id
            };

            return RedirectToAction("Index", indexViewModel);
        }

        [HttpGet]
        public IActionResult Index(IndexViewModel model)
        {
            var dayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var chatBotImage = "CB1A.PNG";
            switch (dayOfWeek)
            {
                case "Monday":
                    chatBotImage = "CB2A.PNG";
                    break;
                case "Tuesday":
                    chatBotImage = "CB3A.PNG";
                    break;
                case "Wednesday":
                    chatBotImage = "CB4A.PNG";
                    break;
                case "Thursday":
                    chatBotImage = "CB5A.PNG";
                    break;
                case "Friday":
                    chatBotImage = "CB6A.PNG";
                    break;
                case "Saturday":
                    chatBotImage = "CB7A.PNG";
                    break;
                case "Sunday":
                    chatBotImage = "CB1A.PNG";
                    break;
            }
            model.BotImage = chatBotImage;

            // It is possible for a person to bookmark the post-sign in index page. The following options are available
            // 1) Secure the site using an Identity system and then put this action (and Save) under the Authorize tag
            // 2) Check the report ID here and if it has already been completed redirect them back to the login page

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}