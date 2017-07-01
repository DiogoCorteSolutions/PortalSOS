
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Application;
using PortalSOS.Dommain;
using PortalSOS.Web.Models;

namespace PortalSOS.Web.Helpers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly Cliente_Application _clieApp;
        private readonly Cofiguracao_Application _cofiguracaoApp;
        public string Roles { get; set; }
        public CustomAuthorizeAttribute()
        {
            _cofiguracaoApp = new Cofiguracao_Application();
            this._clieApp = new Cliente_Application();
        }
        public CustomAuthorizeAttribute(string Roles)
        {
            Roles = Roles;
            _cofiguracaoApp = new Cofiguracao_Application();
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var login = CustomHelper.UsuarioLogado;
            if (login == null)
                return false;

            //var teste = _clieApp.ListarPorCpf(CustomHelper.UsuarioLogado.CPF).IdCliente;
            var teste = _clieApp.ListarPorCpf(CustomHelper.UsuarioLogado.CPF).IdPessoaLoja;

            var result = _cofiguracaoApp.ListarConfigurcooesPorClienteIdAcesso(login.IdCliente, login.IdPerfil);

            if (result != null && result.Count > 0)
                return IsPermission(httpContext, result);


            //var teste = _clieApp.ListarPorCpf(CustomHelper.UsuarioLogado.CPF).IdPessoaLoja;

            //var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente, login.IdPerfil);

            //if (result != null && result.Count > 0)
            //    return IsPermission(httpContext, result);




            //if (login.IdPessoaLoja == 0)
            //{
            //    //var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente);
            //    var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente, login.IdPerfil);

            //    if (result != null && result.Count > 0)
            //        return IsPermission(httpContext, result);

            //}
            //else
            //{
            //    var result = _cofiguracaoApp.ListarConfigurcooesPorLojaId(login.IdPessoaLoja.Value);

            //    if (result != null && result.Count > 0)
            //        return IsPermission(httpContext, result);
            //}



            return false;
        }
        private static bool IsPermission(HttpContextBase httpContext, IList<sosportalconfiguracao_Dommain> result)
        {
            var rd = httpContext.Request.RequestContext.RouteData;
            string action = rd.GetRequiredString("action");
            string controller = rd.GetRequiredString("controller");
            string currentArea = rd.Values["area"] as string;

            var acesso = result.Any(x => x.ControllerAction.ToLower().Contains(controller.ToLower()) && x.IdController == 0 && x.DescricaoTipo == 2);
            if (!acesso)
                return false;

            if (action.ToLower() == "getzip")
                return true;

            return result.Any(x => x.ControllerAction.ToLower().Contains(action.ToLower()) && x.IdController != 0 && x.DescricaoTipo == 1);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult(string.Format("~/login?returnUrl={0}", filterContext.HttpContext.Request.Url.PathAndQuery).ToLower());
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else if (CustomHelper.IsLogado)
            {
                filterContext.Result = new RedirectResult("~/acessonegado");
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }



        //Metodos Teste


        //public LoginViewModels UsuarioLogado
        //{
        //    get { return CommonHelper.GetUser; }
        //}

        //public ISharedAppService SharedAppService
        //{
        //    get { return UnityConfigMvc.GetAppService<ISharedAppService>(); }
        //}

        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{
        //    var login = Loja_Models.GetLogin<sosportalloja_Dommain>();
        //    var result = _cofiguracaoApp.ListarConfigurcooesPorPessoaId(login.IdLoja);

        //    if (result != null && result.Count > 0)
        //        return IsPermission(httpContext, result);

        //    return false;
        //}


        //protected override bool AuthorizeCore(HttpContextBase httpContext)
        //{

        //    var login = CustomHelper.UsuarioLogado;
        //    if (login == null)
        //        return false;

        //    //var teste = _clieApp.ListarPorCpf(CustomHelper.UsuarioLogado.CPF).IdCliente;
        //    var teste = _clieApp.ListarPorCpf(CustomHelper.UsuarioLogado.CPF).IdPessoaLoja;

        //    var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente, login.IdPerfil);

        //    if (result != null && result.Count > 0)
        //        return IsPermission(httpContext, result);




        //    //if (login.IdPessoaLoja == 0)
        //    //{
        //    //    //var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente);
        //    //    var result = _cofiguracaoApp.ListarConfigurcooesPorClienteId(login.IdCliente, login.IdPerfil);

        //    //    if (result != null && result.Count > 0)
        //    //        return IsPermission(httpContext, result);

        //    //}
        //    //else
        //    //{
        //    //    var result = _cofiguracaoApp.ListarConfigurcooesPorLojaId(login.IdPessoaLoja.Value);

        //    //    if (result != null && result.Count > 0)
        //    //        return IsPermission(httpContext, result);
        //    //}



        //    return false;
        //}
        //private static bool IsPermission(HttpContextBase httpContext, IList<sosportalconfiguracao_Dommain> result)
        //{
        //    var rd = httpContext.Request.RequestContext.RouteData;
        //    string action = rd.GetRequiredString("action");
        //    string controller = rd.GetRequiredString("controller");
        //    string currentArea = rd.Values["area"] as string;


        //    //return result.Any(x => x.Controller.ToLower().Contains(controller.ToLower()) && x.ViewName.ToLower().Contains(action.ToLower()));

        //    var acesso = result.Any(x => x.Controller.ToLower().Contains(controller.ToLower()) && x.IdController == 0 && x.DescricaoTipo == 2);
        //    if (!acesso)
        //        return false;

        //    return result.Any(x => x.Controller.ToLower().Contains(action.ToLower()) && x.IdController != 0 && x.DescricaoTipo == 1);

        //}

    }
}