using Dapper.FluentMap.Mapping;

namespace EmployeeChatBot.Models
{
    public class StudentDataModel
    {
        public int UrId { get; set; }

        public string Email { get; set; }
    }

    public class StudentMap : EntityMap<StudentDataModel>
    {
        internal StudentMap()
        {
            Map(u => u.Email).ToColumn("EmailAddress");
        }
    }
}