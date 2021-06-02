using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class UserUpdateInfoContract
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
    }
}
