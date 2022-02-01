using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpendForm.Models
{
    public class Note
    {
        public int issue_iid { get; set; }
        public bool confidential { get; set; }
        public string body{ get; set; }
        public DateTime created_at { get; set; }
    }
}
