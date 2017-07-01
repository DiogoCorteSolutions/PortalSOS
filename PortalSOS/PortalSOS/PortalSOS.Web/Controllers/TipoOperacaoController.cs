using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class TipoOperacaoController : Controller
    {
        private readonly PortalSOS.Application.TipoOperacao_Application _tipoOperacaoApp;
        public TipoOperacaoController()
        {
            this._tipoOperacaoApp = new Application.TipoOperacao_Application();
        }
        //
        // GET: /TipoOperacao/
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View(this._tipoOperacaoApp.ListarTodos());
        }

    }
}
