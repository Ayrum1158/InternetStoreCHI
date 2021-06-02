using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.AppConfig
{
    public static class AppConfig
    {
        public static string ConnectionString { get; }

        static AppConfig()
        {
            string cur = Directory.GetCurrentDirectory();
            string dir = cur.Substring(0, cur.LastIndexOf("\\"));
            dir += "\\Core\\AppConfig\\AppConfig.json";

            var configJson = File.ReadAllText(dir);
            var configData = JObject.Parse(configJson);

            ConnectionString = configData[nameof(ConnectionString)].ToObject<string>();

        }
    }
}
