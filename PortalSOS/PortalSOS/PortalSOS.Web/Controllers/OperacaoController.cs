using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Web.Models;
using PortalSOS.Dommain;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class OperacaoController : BaseController
    {
        private readonly PortalSOS.Application.Operacao_Application _operacaoApp;
        private readonly PortalSOS.Application.TipoOperacao_Application _tipoOperacaoapp;
        public OperacaoController()
        {
            this._operacaoApp = new Application.Operacao_Application();
            this._tipoOperacaoapp = new Application.TipoOperacao_Application();

        }
        //
        // GET: /Operacao/
        [CustomAuthorize]
        public ActionResult OperacaoLista()
        {

            var model = new List<Operacao_Models>();

            foreach (var item in this._operacaoApp.ListarTodos())
            {
                var objeto = new Operacao_Models
                {

                    IdOperacao = item.IdOperacao,
                    IdTipoOperacao = item.IdTipoOperacao,
                    Data = item.Data,
                    Operacao = item.Operacao,
                    Tipo = item.Tipo,
                    Categ = item.Categ,
                    Valor = item.Valor,
                    Ref = item.Ref,
                    Ident = item.Ident,
                    Status = item.Status,
                    Alteracao = item.Alteracao,
                    Caixa = item.Caixa,
                    Turno = item.Turno
                };

                model.Add(objeto);
            }

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult OperacaoCreate()
        {
            var model = new Operacao_Models();

            model.DdlOperacao = OperacaoLista(this._operacaoApp.ListarTodos());
            model.DdlTipoOperacao = TipoOperacaoLista(this._tipoOperacaoapp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult OperacaoCreate(Operacao_Models model)
        {
            try
            {
                var dommain = new sosportaloperacao_Dommain
                {
                    IdOperacao = model.IdOperacao,
                    IdTipoOperacao = model.IdTipoOperacao,
                    Alteracao = model.Alteracao,
                    Categ = model.Categ,
                    Caixa = model.Caixa,
                    Data = DateTime.Now,
                    Ident = model.Ident,
                    Operacao = model.Operacao,
                    Ref = model.Ref,
                    Tipo = model.Tipo,
                    Turno = model.Turno,
                    Valor = model.Valor,
                    Status = model.Status,
                };

                if (ModelState.IsValid)
                {
                    this._operacaoApp.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro salvo com sucesso!";

                }
            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
            }

            return RedirectToAction("Create");
        }
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {

            var filtro = this._operacaoApp.ListarPorId(id);


            var model = new Operacao_Models
            {

                IdOperacao = filtro.IdOperacao,
                IdTipoOperacao = filtro.IdTipoOperacao,
                Alteracao = filtro.Alteracao,
                Categ = filtro.Categ,
                Caixa = filtro.Caixa,
                //Data = filtro.Data,
                Ident = filtro.Ident,
                Operacao = filtro.Operacao,
                Ref = filtro.Ref,
                Tipo = filtro.Tipo,
                Turno = filtro.Turno,
                Status = filtro.Status,
                Valor = filtro.Valor,
            };

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult Edit(Operacao_Models model)
        {
            try
            {
                var filtro = this._operacaoApp.ListarPorId(model.IdOperacao);

                filtro.IdOperacao = model.IdOperacao;
                filtro.IdTipoOperacao = model.IdTipoOperacao;
                filtro.Operacao = model.Operacao;
                filtro.Ref = model.Ref;
                filtro.Status = model.Status;
                filtro.Tipo = model.Tipo;
                filtro.Turno = model.Turno;
                filtro.Valor = model.Valor;


                if (ModelState.IsValid)
                {
                    this._operacaoApp.Atualizar(filtro);
                    TempData["msgsucesso"] = "Registro atualizado com sucesso!";
                }
                return View(model);

            }
            catch (Exception exception)
            {

                TempData["msgerro"] = exception.Message.ToString();
                return View(model);
            }

        }
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            var filtro = this._operacaoApp.ListarPorId(id);

            var model = new Operacao_Models
            {
                IdOperacao = filtro.IdOperacao,
                IdTipoOperacao = filtro.IdTipoOperacao,
                Alteracao = filtro.Alteracao,
                Caixa = filtro.Caixa,
                Categ = filtro.Categ,
                Data = filtro.Data,
                Operacao = filtro.Operacao,
                Valor = filtro.Valor,
                Ident = filtro.Ident,
                Turno = filtro.Turno,
                Status = filtro.Status,
                Ref = filtro.Ref,
                Tipo = filtro.Tipo,

            };
            model.DdlTipoOperacao = TipoOperacaoLista(this._tipoOperacaoapp.ListarTodos());

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult Excluir(int id)
        {
            try
            {
                this._operacaoApp.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("index", "operacao");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("index", "operacao");
            }
        }

    }
}
