using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalSOS.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly PortalSOS.Application.Produto_Application _produtoLista;

        public ProdutoController()
        {
            this._produtoLista = new Application.Produto_Application();
        }
        //
        // GET: /Produto/


        public ActionResult Index()
        {
            return View(this._produtoLista.ListarTodos());
        }

       
        //public ActionResult ListarParticipante(string cpf = null)
        //{
        //    var result = new object();

        //    if (cpf == null)
        //        result = _participante.ListarTodosParticipantePerfil();

        //    else
        //        result = _participante.ListarParticipantePorCpf(cpf);

        //    return View(result);


        //}
        //public ActionResult ListarEmailParticipante(string cpf = null)
        //{
        //    var retorno = new object();

        //    if (cpf == null)
        //    {
        //        retorno = this._participanteEmail.ListarTodosEmail();
        //    }
        //    else
        //    {

        //        retorno = this._participanteEmail.ListarEmailParticipantePorCpf(cpf);
        //    }
        //    return View(retorno);

        //}
        //public ActionResult AlterarEmail()
        //{
        //    var dto = new AlterarEmail();

        //    return View(dto);
        //}
        //[HttpPost]
        //public ActionResult AlterarEmail(AlterarEmail dto)
        //{
        //    try
        //    {
        //        this._participanteEmail.Alteraremail(dto);

        //    }
        //    catch (Exception)
        //    {


        //        throw;
        //    }

        //    TempData["msgsucesso"] = "E-mail alterado com sucesso";
        //    return RedirectToAction("AlterarEmail");
        //}


        //public ActionResult AlterarPerfil()
        //{
        //    var dto = new AlterarPerfil();

        //    dto.DdlPerfil = PerfilLista(this._participante.ListarPerfil());

        //    return View(dto);


    }
}
