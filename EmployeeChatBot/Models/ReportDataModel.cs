using Dapper.FluentMap.Mapping;
using System;

namespace EmployeeChatBot.Models
{
    public class ReportDataModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int UrId { get; set; }

        public bool Fever { get; set; }

        public bool Coughing { get; set; }

        public bool Breathing { get; set; }

        public bool SoreThroat { get; set; }

        public bool BodyAches { get; set; }

        public bool Allergies { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public bool IsPositive()
        {
            if (Fever == true || Coughing == true || Breathing == true || (SoreThroat == true && Allergies == false) || BodyAches == true)
                return true;
            else
                return false;
        }
    }

    public class ReportMap : EntityMap<ReportDataModel>
    {
        internal ReportMap()
        {
            Map(u => u.UrId).ToColumn("Employee_UrId");
            Map(u => u.Username).ToColumn("Employee_AdUsername");
            Map(u => u.Email).ToColumn("Employee_Email");
            Map(u => u.Id).ToColumn("Report_ID");
        }
    }
}
