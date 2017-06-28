using System.Web;
using System.Web.SessionState;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public class SessionHelper
    {
        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static bool Exists(string key)
        {
            return Session[key] != null;
        }

        public static void Remove(string key)
        {
            Session[key] = null;
        }

        public static object Get(string key)
        {
            return Exists(key) ? (object)Session[key] : null;
        }

        public static T Get<T>(string key) where T : class
        {
            return Exists(key) ? (T)Session[key] : null;
        }

        public static void Set(string key, object objeto)
        {
            Session[key] = objeto;
        }
    }
}