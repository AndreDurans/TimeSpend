using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpendForm.Models
{
    public class LogWork
    {
        public string Url { get; set; }
        public int ProjectId { get; set; }
        public int IssueId { get; set; }
        public Note Note { get; set; }
        public string PersonalToken { get; set; }
    }

    public class LogWorkSuccess
    {

    }
}
