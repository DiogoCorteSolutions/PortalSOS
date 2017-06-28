using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using PortalSOS.Application;
using PortalSOS.Dommain;
using PortalSOS.Web.Models;

namespace PortalSOS.Web.Helpers
{
    public static class CustomHelper
    {
        private const string sessionUser = "sessionUser";
        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static bool IsLogado
        {
            get
            {
                return (Session[sessionUser] != null);
            }
        }

        public static Cliente_Models UsuarioLogado
        {
            get
            {
                return GetLogin<Cliente_Models>();
            }
        }

        public static void LogOff()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }
        public static void SetId(int idloja)
        {
            Session[sessionUser] = idloja;
        }

        public static void SetLogin(object model)
        {
            Session[sessionUser] = model;
        }

        private static T GetLogin<T>() where T : class
        {
            return (T)Session[sessionUser];
        }

        public static IList<sosportalmenu_Dommain> ListarMenu
        {
            get
            {
                if (!IsLogado)
                    return null;
                Cofiguracao_Application _cofiguracaoApplication = new Cofiguracao_Application();
                return _cofiguracaoApplication.ListarMenuPorClienteId(UsuarioLogado.IdPessoaLoja.Value, UsuarioLogado.IdPerfil);

            }
        }

        //Metodos Teste
        //public static IList<sosportalmenu_Dommain> ListarMenu
        //{
        //    get
        //    {
        //        if (!IsLogado)
        //            return null;
        //        Cofiguracao_Application _cofiguracaoApplication = new Cofiguracao_Application();
        //        return _cofiguracaoApplication.ListarMenuPorClienteId(UsuarioLogado.IdPessoaLoja.Value, UsuarioLogado.IdPerfil);

        //        //return _cofiguracaoApplication.ListarMenuPorClienteId(UsuarioLogado.IdPessoaLoja.Value);

        //        //return _cofiguracaoApplication.ListarMenuPorClienteId(UsuarioLogado.IdCliente);
        //    }
        //}
    }
}