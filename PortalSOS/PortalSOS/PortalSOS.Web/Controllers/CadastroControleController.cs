using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    //[CustomAuthorize]
    public class CadastroControleController : Controller
    {
        private readonly PortalSOS.Application.Cofiguracao_Application _configuracaApp;
        public CadastroControleController()
        {
            this._configuracaApp = new Application.Cofiguracao_Application();
        }
        //[CustomAuthorize]
        public ActionResult PaginaAcessoLista()
        {
            return View(this._configuracaApp.ListarTodos());

        }
        //[CustomAuthorize]
        public ActionResult PaginaAcessoCreate()
        {
            var model = new Configuracao_Models();
            return View(model);
        }
        //[HttpPost, CustomAuthorize]
        [HttpPost]
        public ActionResult PaginaAcessoCreate(Configuracao_Models model)
        {
            var existControle = this._configuracaApp.ExisteControlle(model.ControllerAction);

            if (existControle != true)
            {
                var fitro = this._configuracaApp.ListarTodos();

                try
                {
                    var dommain = new sosportalconfiguracao_Dommain
                    {

                        ControllerAction = model.ControllerAction,
                        IdController = 0,
                        Status = true,
                        DescricaoTipo = 2,

                    };

                    if (ModelState.IsValid)
                    {
                        this._configuracaApp.Salvar(dommain);
                        TempData["msgsucesso"] = "Registro salvo com sucesso";

                    }

                }
                catch (Exception exception)
                {
                    TempData["msgerror"] = exception.Message.ToString();
                    return View(model);
                }
                return RedirectToAction("PaginaAcessoCreate");


            }
            else
            {
                TempData["msgsucesso"] = "Registro salvo com sucesso";


            }
            return RedirectToAction("PaginaAcessoCreate");

        }



    }
}
