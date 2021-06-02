using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class NewUserContract
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
