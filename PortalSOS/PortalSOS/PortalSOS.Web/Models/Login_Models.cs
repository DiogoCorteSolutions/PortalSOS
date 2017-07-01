using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortalSOS.Web.Models
{
    public class Login_Models
    {
        private const string sessionUser = "sessionUser";

        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static bool IsLogado() { return (Session[sessionUser] != null); }

        public static void LogOff()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }

    }
}