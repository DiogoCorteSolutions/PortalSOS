using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using PortalSos.Infra.CrossCutting.Common.Security;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public static class CookiesHelper
    {
        public static bool Exists
        {
            get
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains(keyCookie))
                    return HttpContext.Current.Request.Cookies[keyCookie].Value != null;

                return false;
            }
        }

        public static bool Exist(string key)
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains(key))
                return HttpContext.Current.Request.Cookies[key].Value != null;

            return false;
        }

        public static IDictionary<string, string> Get
        {
            get
            {
                var resultDictionary = new Dictionary<string, string>();

                if (HttpContext.Current.Request.Cookies.AllKeys.Contains(keyCookie))
                {
                    var resultCookies = HttpContext.Current.Request.Cookies[keyCookie].Values;

                    var keys = resultCookies.AllKeys.ToList();

                    foreach (var item in keys)
                    {
                        var keyName = item;
                        var value = (resultCookies.GetValues(item) != null && resultCookies.GetValues(item).Count() > 0)
                            ? resultCookies.GetValues(item)[0] : null;

                        if (value != null && keyName != null)
                            resultDictionary.Add(keyName, value);
                    }
                }

                return resultDictionary;
            }
        }

        public static T GetObject<T>() where T : class
        {
            if (HttpContext.Current.Response.Cookies[keyCookie] == null)
                throw new KeyNotFoundException(string.Format("Chave {0} não encontrada.", keyCookie));

            return (T)Convert.ChangeType(System.Web.HttpContext.Current.Request.Cookies[keyCookie].Value, typeof(T), CultureInfo.InvariantCulture);
        }

        public static T GetUserLogged<T>() where T : class
        {
            if (Exists)
            {
                var httpCookie = HttpContext.Current.Request.Cookies.Get(keyCookie);

                if (httpCookie != null)
                {
                    var jsonCookie = CriptografiaSecurity.Decrypt256(Convert.FromBase64String(httpCookie.Value));

                    return JsonConvert.DeserializeObject<T>(jsonCookie);
                }
            }

            return null;
        }

        public static T GetUserLogged<T>(string key) where T : class
        {
            if (Exist(key))
            {
                var httpCookie = HttpContext.Current.Request.Cookies.Get(key);

                if (httpCookie != null)
                {
                    var jsonCookie = CriptografiaSecurity.Decrypt256(Convert.FromBase64String(httpCookie.Value));

                    return JsonConvert.DeserializeObject<T>(jsonCookie);
                }
            }

            return null;
        }

        public static string GetTokenNotEncrypt(string key)
        {
            if (Exist(key))
            {
                var httpCookie = HttpContext.Current.Request.Cookies.Get(key);

                if (httpCookie != null)
                    return httpCookie.Value;
            }

            return null;
        }

        public static void Set<TEntity>(TEntity entity, int minutes = 10080) where TEntity : class
        {
            // seleciona nomes e valores da entidade
            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties();

            var resultCookies = HttpContext.Current.Request.Cookies[keyCookie];

            HttpCookie cookiesList = new HttpCookie(keyCookie);

            foreach (PropertyInfo item in propertyInfos)
            {
                var value = (item.GetValue(entity, null) != null) ? item.GetValue(entity, null).ToString() : null;

                if (value != null)
                    // seta o valor no cookies
                    Set(item.Name, value, cookiesList);
            }

            // seta o tempo de permanencia do mesmo
            cookiesList.Expires = DateTime.Now.AddMinutes(minutes);

            HttpContext.Current.Response.Cookies.Add(cookiesList);
        }

        public static void SetWithParam(IDictionary<string, string> param, int minutes = 10080)
        {
            var resultCookies = HttpContext.Current.Request.Cookies[keyCookie];

            HttpCookie cookiesList = new HttpCookie(keyCookie);

            foreach (var item in param)
                Set(item.Key, item.Value, cookiesList);

            // seta o tempo de permanencia do mesmo
            cookiesList.Expires = DateTime.Now.AddMinutes(minutes);

            HttpContext.Current.Response.Cookies.Add(cookiesList);
        }

        public static void SetWithParam(string data, int minutes = 10080)
        {
            var resultCookies = HttpContext.Current.Request.Cookies[keyCookie];
            HttpCookie cookie = new HttpCookie(keyCookie);
            cookie.Value = data;
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMinutes(minutes);
            HttpContext.Current.Response.SetCookie(cookie);
        }

        public static void SetWithParam(string key, string data, int minutes = 10080)
        {
            var resultCookies = HttpContext.Current.Request.Cookies[key];
            HttpCookie cookie = new HttpCookie(key);
            cookie.Value = data;
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddMinutes(minutes);
            HttpContext.Current.Response.SetCookie(cookie);
        }

        public static void Remove()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Request.Cookies.Remove(keyCookie);
            HttpContext.Current.Request.Cookies.Clear();

            var resetSessionCookie = new HttpCookie(keyCookie);
            resetSessionCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(resetSessionCookie);

            //Limpar o cookie de Autenticação
            var resetFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            resetFormsCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(resetFormsCookie);

            //Invalida o Cache no lado do Cliente
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        public static void Remove(string key)
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Request.Cookies.Remove(key);
            HttpContext.Current.Request.Cookies.Clear();

            var resetSessionCookie = new HttpCookie(key);
            resetSessionCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(resetSessionCookie);

            //Limpar o cookie de Autenticação
            var resetFormsCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            resetFormsCookie.Expires = DateTime.Now.AddYears(-1);
            HttpContext.Current.Response.Cookies.Add(resetFormsCookie);

            //Invalida o Cache no lado do Cliente
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        #region Privados

        public static string keyCookie = "_dataTokenFmais";

        private static void Set(string name, string value, HttpCookie cookiesList)
        {
            cookiesList.Values.Add(new NameValueCollection {
                { name, value }
            });
        }

        #endregion
    }
}
