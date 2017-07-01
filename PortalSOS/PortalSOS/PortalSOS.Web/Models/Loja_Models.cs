using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using PortalSOS.Dommain;

namespace PortalSOS.Web.Models
{
    public class Loja_Models : BaseModels
    {
        public int IdLoja { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public Nullable<System.DateTime> Datacadastro { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public bool Status { get; set; }
        public string ResponsavelCadastro { get; set; }
        public string Senha { get; set; }
        public string PerfilLoja { get; set; }
        public int IdPerfil { get; set; }
        public string CPF { get; set; }
        public string Obs { get; set; }
        public string Email { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CNAE { get; set; }


        private const string sessionUser = "sessionUser";

        private static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static bool IsLogadoLoja() { return (Session[sessionUser] != null); }

        public static void LogOff()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }

        public static Cliente_Models GetLoginLojaModel()
        {
            return !IsLogadoLoja() ? null : (Cliente_Models)Session[sessionUser];
        }

        public static void SetLogin(object model)
        {
            Session[sessionUser] = model;
        }

        public static T GetLogin<T>() where T : class
        {
            return (T)Session[sessionUser];
        }


    }
}