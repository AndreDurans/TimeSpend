using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSpendForm.Core
{
    public enum ProjectsEnum
    {
        [Description("Selecione")]
        Selecione = 0,

        [Description("CEFW")]
        CEFW = 25906077,

        [Description("JFSP")]
        JFSP = 25680287,

        [Description("REFI")]
        REFI = 25904984,

        [Description("RMAL")]
        RMAL = 25905921,

        [Description("TJSP")]
        TJSP = 25903630,

        [Description("HANG FIRE")]
        HANGFIRE = 26814866
         
    }
}
