﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contracts.PL_BL
{
    public class LoggedInContract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
    }
}
