using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Dommain;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class ContasAPagarController : BaseController
    {
        private readonly PortalSOS.Application.ContasAPagar_Application _contasAPagarApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;

        public ContasAPagarController()
        {
            this._contasAPagarApp = new Application.ContasAPagar_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //
        // GET: /ContasAPagar/
        [CustomAuthorize]
        public ActionResult ContasAPagarLista()
        {

            var model = new List<ContasAPagar_Models>();

            foreach (var item in this._contasAPagarApp.ListarTodos())
            {
                var objeto = new ContasAPagar_Models
                {
                    IdContasAPagar = item.IdContasAPagar,
                    Data = item.Data,
                    Fornecedor = item.Fornecedor,
                    Identificacao = item.Identificacao,
                    Nota = item.Nota,
                    Faturado = item.Faturado,
                    Boleto = item.Boleto,
                    Vencimento = item.Vencimento,
                    valor = item.valor,
                    Parcela = item.Parcela,
                    Nf = item.Nf,
                    Nfatura = item.Nfatura,
                    Status = item.Status,
                    IdCliente = item.IdCliente,
                };

                model.Add(objeto);


            }
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult ContasAPagarCreate()
        {
            var model = new ContasAPagar_Models();

            model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult ContasAPagarCreate(ContasAPagar_Models model)
        {
            try
            {
                var dommain = new sosportalcontasapagar_Dommain
                {
                    IdContasAPagar = model.IdContasAPagar,
                    Data = DateTime.Now,
                    Fornecedor = model.Fornecedor,
                    Identificacao = model.Identificacao,
                    Nota = model.Nota,
                    Faturado = model.Faturado,
                    Boleto = model.Boleto,
                    Vencimento = DateTime.Now,
                    valor = model.valor,
                    Parcela = model.Parcela,
                    Nf = model.Nf,
                    Nfatura = model.Nfatura,
                    Status = model.Status,
                    IdCliente = model.IdCliente,

                };

                if (ModelState.IsValid)
                {
                    this._contasAPagarApp.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro salvo com sucesso";

                    model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());
                }
                else
                {
                    TempData["msgerror"] = "Erro ao tentar salvar os dados";

                    model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

                    //return View(model);

                }

            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
            }
            return RedirectToAction("Create");
        }
        //[HttpPost]
        //public ActionResult ContasAPagarCreate(ContasAPagar_Models model)
        //{
        //    try
        //    {
        //        var dommain = new sosportalcontasapagar_Dommain
        //        {
        //            IdContasAPagar = model.IdContasAPagar,
        //            Data = DateTime.Now,
        //            Fornecedor = model.Fornecedor,
        //            Identificacao = model.Identificacao,
        //            Nota = model.Nota,
        //            Faturado = model.Faturado,
        //            Boleto = model.Boleto,
        //            Vencimento = DateTime.Now,
        //            valor = model.valor,
        //            Parcela = model.Parcela,
        //            Nf = model.Nf,
        //            Nfatura = model.Nfatura,
        //            Status = model.Status,
        //            IdLoja = model.IdLoja

        //        };

        //        if (ModelState.IsValid)
        //        {
        //            this._contasAPagarApp.Salvar(dommain);
        //            TempData["msgsucesso"] = "Registro salvo com sucesso!";

        //            model.DdlLoja = LojaLista(this._lojaApp.ListarTodos());
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return View(model);
        //    }
        //    return RedirectToAction("create");

        //}


        //[HttpPost]
        //public ActionResult ContasAPagarCreate(ContasAPagar_Models model)
        //{
        //    try
        //    {
        //        var dommain = new sosportalcontasapagar_Dommain
        //        {
        //            IdContasAPagar = model.IdContasAPagar,
        //            Data = DateTime.Now,
        //            Fornecedor = model.Fornecedor,
        //            Identificacao = model.Identificacao,
        //            Nota = model.Nota,
        //            Faturado = model.Faturado,
        //            Boleto = model.Boleto,
        //            Vencimento = DateTime.Now,
        //            valor = model.valor,
        //            Parcela = model.Parcela,
        //            Nf = model.Nf,
        //            Nfatura = model.Nfatura,
        //            Status = model.Status,
        //            IdLoja = model.IdLoja
        //        };

        //        if (ModelState.IsValid)
        //        {
        //            this._contasAPagarApp.Salvar(dommain);
        //            TempData["msgsucesso"] = "Registro salvo com sucesso!";

        //            model.DdlLoja = LojaLista(this._lojaApp.ListarTodos());
        //        }

        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return View(model);
        //    }
        //    return RedirectToAction("Create");
        //}
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {

            var filtro = this._contasAPagarApp.ListarPorId(id);


            var model = new ContasAPagar_Models
            {

                IdCliente = filtro.IdCliente,
                IdContasAPagar = filtro.IdContasAPagar,
                Vencimento = filtro.Vencimento,
                Fornecedor = filtro.Fornecedor,
                Identificacao = filtro.Identificacao,
                Nota = filtro.Nota,
                Faturado = filtro.Faturado,
                Boleto = filtro.Boleto,
                valor = filtro.valor,
                Parcela = filtro.Parcela,
                Nf = filtro.Nf,
                Nfatura = filtro.Nfatura,
                Status = filtro.Status

            };
            model.DdlCnpj = CnpjLista(this._clienteApp.ListarTodos());
            model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult Edit(ContasAPagar_Models model)
        {
            try
            {
                var filtro = this._contasAPagarApp.ListarPorId(model.IdContasAPagar);

                filtro.IdContasAPagar = model.IdContasAPagar;
                filtro.IdCliente = model.IdCliente;
                filtro.Fornecedor = model.Fornecedor;
                filtro.Identificacao = model.Identificacao;
                filtro.Nota = model.Nota;
                filtro.Faturado = model.Faturado;
                filtro.Boleto = model.Boleto;
                filtro.valor = model.valor;
                filtro.Parcela = model.Parcela;
                filtro.Nf = model.Nf;
                filtro.Nfatura = model.Nfatura;
                filtro.Status = model.Status;

                if (ModelState.IsValid)
                {
                    this._contasAPagarApp.Atualizar(filtro);
                    TempData["msgsucesso"] = "Registro atualizado com sucesso!";

                }


                model.DdlCnpj = CnpjLista(this._clienteApp.ListarTodos());
                model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

                return View(model);
            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
            }
        }
        [CustomAuthorize]
        public ActionResult Details(int id)
        {
            var filtro = this._contasAPagarApp.ListarPorId(id);


            var model = new ContasAPagar_Models
            {
                IdContasAPagar = filtro.IdContasAPagar,
                Data = filtro.Data,
                Fornecedor = filtro.Fornecedor,
                Identificacao = filtro.Identificacao,
                Nota = filtro.Nota,
                Faturado = filtro.Faturado,
                Boleto = filtro.Boleto,
                Vencimento = filtro.Vencimento,
                valor = filtro.valor,
                Parcela = filtro.Parcela,
                Nf = filtro.Nf,
                Nfatura = filtro.Nfatura,
                Status = filtro.Status,
                IdCliente = filtro.IdCliente,

            };


            return View(model);
        }
        [CustomAuthorize]
        public ActionResult Excluir(int id)
        {
            try
            {
                this._contasAPagarApp.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("index", "contasAPagar");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("index", "contasAPagar");
            }
        }
        
    }
}
