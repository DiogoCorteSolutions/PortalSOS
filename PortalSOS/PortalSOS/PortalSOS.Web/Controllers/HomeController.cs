using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;

        public HomeController()
        {
            this._clienteApp = new Application.Cliente_Application();
        }
        ////
        //// GET: /hOME/
        [CustomAuthorize]
        public ActionResult Index()
        {
            //var count = 0;
            //var emAtraso = 0;

            //if (Loja_Models.IsLogadoLoja())
            //{
            //    if (Loja_Models.GetLoginLojaModel().PerfilLoja.Contains("loja"))
            //    {
            //        //count = this._locacaoBusiness.ListarCount(LoginModels.GetLoginModel().Id);
            //        emAtraso = this._clienteApp.ListarTodosPreCad(Cliente_Models.GetLoginLojaModel().IdLoja);
            //    }
            //    else
            //    {
            //        count = this._clienteApp.ListarTodosPreCad(0);
            //        //emAtraso = this._locacaoBusiness.ListarEmAtraso(0);
            //    }
            //}

            ////ViewBag.Atraso = emAtraso;
            //ViewBag.Count = count;


            return View();

        }
        //public ActionResult Informacoes ()
        //{
        //    return View(CustomHelper.UsuarioLogado.Pessoa());
        //}
        //public ActionResult Index()
        //{
        //    var count = 0;
        //    var emAtraso = 0;

        //    count = this._lojaApp.ListarTodos

        //    if (Loja_Models.IsLogado())
        //    {
        //        if (Loja_Models.GetLoginModel().DdlTipoOperac.Contains("cliente"))
        //        {
        //            count = this._locacaoBusiness.ListarCount(LoginModels.GetLoginModel().Id);
        //            emAtraso = this._locacaoBusiness.ListarEmAtraso(LoginModels.GetLoginModel().Id);
        //        }
        //        else
        //        {
        //            count = this._locacaoBusiness.ListarCount(0);
        //            emAtraso = this._locacaoBusiness.ListarEmAtraso(0);
        //        }
        //    }

        //    ViewBag.Atraso = emAtraso;
        //    ViewBag.Count = count;


        //    return View();

        //}

    }
}
