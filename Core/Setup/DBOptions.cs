using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Setup
{
    public class DBOptions
    {
        public const string DBOptionsKey = "DBOptions";// key in (appsettings.json)?

        public string ConnectionString { get; set; }
    }
}
