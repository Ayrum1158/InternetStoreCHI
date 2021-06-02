using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class LoggingInContract
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
