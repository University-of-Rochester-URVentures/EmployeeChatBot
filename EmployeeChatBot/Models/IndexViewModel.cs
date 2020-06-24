using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeChatBot.Models
{
    public class IndexViewModel
    {
        public string BotImage { get; set; }

        public string ReportedOn { get; set; }

        public bool HasReport { get; set; }

        public bool IsPositiveReport { get; set; }

        public int ReportId { get; set; }
    }
}
