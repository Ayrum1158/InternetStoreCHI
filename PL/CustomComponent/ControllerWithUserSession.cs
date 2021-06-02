using Core.Contracts.PL_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.CustomComponent
{
    public class ControllerWithUserSession : Controller
    {
        private const string userIdKey = "userId";
        private const string userNameKey = "userName";
        private const string userLoggedInKey = "userLoggedIn";

        protected LoggedInContract SessionLoggedInInfo
        {
            get
            {
                string json = HttpContext.Session.GetString(userLoggedInKey);
                return JsonConvert.DeserializeObject<LoggedInContract>(json);
            }
            set
            {
                string json = JsonConvert.SerializeObject(value);
                HttpContext.Session.SetString(userLoggedInKey, json);
                SessionUserId = value.Id;
                SessionUserName = value.Name;
            }
        }
        protected int? SessionUserId
        {
            get { return HttpContext.Session.GetInt32(userIdKey); }
            private set { HttpContext.Session.SetInt32(userIdKey, (int)value); }
        }
        protected string SessionUserName
        {
            get { return HttpContext.Session.GetString(userNameKey); }
            private set { HttpContext.Session.SetString(userNameKey, value); }
        }

        protected void ClearSessionData()
        {
            HttpContext.Session.Clear();
        }
    }
}
