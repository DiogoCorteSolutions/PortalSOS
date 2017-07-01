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
    [CustomAuthorize]
    public class ContasAReceberController : BaseController
    {
        private readonly PortalSOS.Application.ContasAReceber_Application _contasAReceber;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        public ContasAReceberController()
        {
            this._contasAReceber = new Application.ContasAReceber_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //
        // GET: /ContasAReceber/
        public ActionResult ContasAReceberLista()
        {

            var model = new List<ContasAReceber_Models>();
            foreach (var item in this._contasAReceber.ListarTodos())
            {
                var objeto = new ContasAReceber_Models
                {
                    IdContasAReceber = item.IdContasAReceber,
                    Data = item.Data,
                    Cliente = item.Cliente,
                    Nota = item.Nota,
                    Faturado = item.Faturado,
                    Valor = item.Valor,
                    //Vencimento = model.Vencimento,
                    Parcela = item.Parcela,
                    Pedido = item.Pedido,
                    FrmPgt = item.FrmPgt,
                    Ndoc = item.Ndoc,
                    Status = item.Status,
                    StatusPed = item.StatusPed,
                    IdCliente = item.IdCliente,
                };

                model.Add(objeto);

            }
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult ContasAReceberCreate()
        {
            var model = new ContasAReceber_Models();

            model.DdlClienteLista = ClienteLista(this._clienteApp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult ContasAReceberCreate(ContasAReceber_Models model)
        {
            try
            {
                var dommain = new sosportalcontasareceber_Dommain
                {
                    Data = DateTime.Now,
                    Cliente = model.Cliente,
                    Nota = model.Nota,
                    Faturado = model.Faturado,
                    Valor = model.Valor,
                    Vencimento = DateTime.Now,
                    Parcela = model.Parcela,
                    Pedido = model.Pedido,
                    FrmPgt = model.FrmPgt,
                    Ndoc = model.Ndoc,
                    Status = model.Status,
                    StatusPed = model.StatusPed,
                    IdCliente = model.IdCliente,

                };

                if (ModelState.IsValid)
                {
                    this._contasAReceber.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro salvo com sucesso";


                    model.DdlClienteLista = ClienteLista(this._clienteApp.ListarTodos());

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
            return RedirectToAction("create");
        }
        public ActionResult Edit(int id)
        {

            var filtro = this._contasAReceber.ListarPorId(id);


            var model = new ContasAReceber_Models
            {

                IdContasAReceber = filtro.IdContasAReceber,
                IdCliente = filtro.IdCliente,
                Data = filtro.Data,
                Cliente = filtro.Cliente,
                Nota = filtro.Nota,
                Faturado = filtro.Faturado,
                Valor = filtro.Valor,
                //Vencimento = filtro.Vencimento,
                Parcela = filtro.Parcela,
                Pedido = filtro.Pedido,
                FrmPgt = filtro.FrmPgt,
                Ndoc = filtro.Ndoc,
                Status = filtro.Status,
                StatusPed = filtro.StatusPed


            };
            model.DdlCnpj = CnpjLista(this._clienteApp.ListarTodos());
            model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult Edit(ContasAReceber_Models model)
        {
            try
            {
                var filtro = this._contasAReceber.ListarPorId(model.IdContasAReceber);


                filtro.IdContasAReceber = model.IdContasAReceber;
                filtro.IdCliente = model.IdCliente;
                //filtro.Data = model.Data;
                filtro.Cliente = model.Cliente;
                filtro.Nota = model.Nota;
                filtro.Faturado = model.Faturado;
                filtro.Valor = model.Valor;
                //filtro.Vencimento = model.Vencimento;
                filtro.Parcela = model.Parcela;
                filtro.Pedido = model.Pedido;
                filtro.FrmPgt = model.FrmPgt;
                filtro.Ndoc = model.Ndoc;
                filtro.Status = model.Status;
                filtro.StatusPed = model.StatusPed;



                if (ModelState.IsValid)
                {
                    this._contasAReceber.Atualizar(filtro);
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
        public ActionResult Details(int id)
        {
            var filtro = this._contasAReceber.ListarPorId(id);

            var model = new ContasAReceber_Models
            {
                IdContasAReceber = filtro.IdContasAReceber,
                Cliente = filtro.Cliente,
                Data = filtro.Data,
                Faturado = filtro.Faturado,
                FrmPgt = filtro.FrmPgt,
                IdCliente = filtro.IdCliente,
                Ndoc = filtro.Ndoc,
                Nota = filtro.Nota,
                Parcela = filtro.Parcela,
                Pedido = filtro.Pedido,
                Status = filtro.Status,
                StatusPed = filtro.StatusPed,
                Valor = filtro.Valor,
                Vencimento = filtro.Vencimento,

            };

            model.DdlCnpj = CnpjLista(this._clienteApp.ListarTodos());


            return View(model);
        }
        public ActionResult Excluir(int id)
        {
            try
            {
                this._contasAReceber.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("index", "contasAReceber");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("index", "contasAReceber");
            }
        }

    }
}
