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
    //CadastroActionLista
    public class CadastroActionController : BaseController
    {
        private readonly PortalSOS.Application.Cofiguracao_Application _configuracaApp;
        public CadastroActionController()
        {
            this._configuracaApp = new Application.Cofiguracao_Application();
        }
        //[CustomAuthorize]
        public ActionResult CadastroActionLista()
        {

            var model = new List<Configuracao_Models>();

            foreach (var item in this._configuracaApp.ListarTodos())
            {
                var objeto = new Configuracao_Models
                {

                    ControllerAction = item.ControllerAction,
                    ViewName = item.ViewName,
                    DescricaoTipoo = item.DescricaoTipo,

                };

                model.Add(objeto);
            }

            return View(model);
        }
        //[CustomAuthorize]
        public ActionResult CadastroActionCreate()
        {

            var model = new Configuracao_Models();

            model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
            return View(model);
        }
        //[HttpPost, CustomAuthorize]
        [HttpPost]
        public ActionResult CadastroActionCreate(Configuracao_Models model)
        {
            var verificaaction = this._configuracaApp.ExisteAction(model.ControllerAction, model.IdController);

            if (verificaaction != true)
            {
                try
                {
                    model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
                    var dommain = new sosportalconfiguracao_Dommain
                    {
                        ControllerAction = model.ControllerAction,
                        IdController = model.IdController,
                        Status = true,
                        ViewName = model.ControllerAction,
                        DescricaoTipo = 1,

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
                return RedirectToAction("CadastroActionCreate");

            }
            else
            {
                TempData["msgsucesso"] = "Ja existe um view com esse nome";
            }
            return RedirectToAction("CadastroActionCreate");
        }

    }
}
