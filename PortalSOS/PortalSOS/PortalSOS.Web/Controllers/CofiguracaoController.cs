using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCheckBoxList.Model;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    [CustomAuthorize]
    public class ConfiguracaoController : BaseController
    {
        private readonly PortalSOS.Application.Cofiguracao_Application _confingApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        private readonly PortalSOS.Application.Perfil_Application _perfilApp;
        public ConfiguracaoController()
        {
            this._confingApp = new Application.Cofiguracao_Application();
            this._clienteApp = new Application.Cliente_Application();
            this._perfilApp = new Application.Perfil_Application();
        }
        [CustomAuthorize]
        public ActionResult Index()
        {
            var model = new List<Configuracao_Models>();

            foreach (var item in this._confingApp.ListarTodos())
            {
                var objeto = new Configuracao_Models
                {
                    IdConfiguracao = item.IdConfiguracao,
                    ControllerAction = item.ControllerAction,
                    IdController = item.IdController,

                };



                model.Add(objeto);
            }
            return View(model);
        }
        //public ActionResult Create()
        //{
        //    var model = new Configuracao_Models();
        //    model.DdlConfiguracaoListaController = ConfiguracaoListaController(_confingApp.ListarTodos());
        //    //model.DdlConfiguracaoListaControllerPoorFiltro = ConfiguracaoListaControllerPoorFiltro(_confingApp.ListarTodos());

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Create(Configuracao_Models model)
        //{

        //    try
        //    {
        //        var dommain = new sosportalconfiguracao_Dommain
        //        {
        //            IdConfiguracao = model.IdConfiguracao,
        //            Controller = model.Controller,
        //            ViewName = model.Controller,
        //            //ViewName = model.ViewName,
        //            IdController = model.IdController,
        //            Status = true,
        //            DescricaoTipo = 1,
        //        };



        //        if (ModelState.IsValid)
        //        {
        //            this._confingApp.Salvar(dommain);
        //            TempData["msgsucesso"] = "Registro salvo com sucesso";

        //            model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._confingApp.ListarTodos());
        //        }
        //        else
        //        {
        //            TempData["msgerror"] = "Erro ao tentar salvar os dados";


        //        }

        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return View(model);
        //    }
        //    return RedirectToAction("Create");
        //}
        //[CustomAuthorize]
        public ActionResult Create()


        {
            var model = new Configuracao_Models();
            this.Listas(model);

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        //[HttpPost]
        public ActionResult Create(Configuracao_Models model)
        {
            try
            {
                this.Listas(model);

                if (Session["_locacao_"] != null)
                {
                    var lista = (List<Configuracao_Models>)Session["_locacao_"];

                    foreach (var item in lista)
                    {
                        var dto = new sosportalconfiguracao_Dommain
                        {
                            IdConfiguracao = item.IdConfiguracao,
                            IdController = item.IdConfiguracao,
                            ControllerAction = item.ControllerAction,
                            DescricaoTipo = item.DescricaoTipoo,
                            Status = item.Status,
                            ViewName = item.ViewName,
                        };

                        this._confingApp.Salvar(dto);
                    }

                    TempData["msgsucesso"] = "Registro salvo com sucesso.";

                    Session["_locacao_"] = null;
                }
            }
            catch (Exception execption)
            {
                TempData["msgerror"] = execption.Message.ToString();
            }

            return View(model);

        }
        //public ActionResult Create(Configuracao_Models model)
        //{
        //    try
        //    {
        //        this.Listas(model);

        //        if (Session["_locacao_"] != null)
        //        {
        //            var lista = (List<Configuracao_Models>)Session["_locacao_"];

        //            foreach (var item in lista)
        //            {
        //                var dommain = new sosportalconfiguracao_Dommain
        //                {
        //                    IdConfiguracao = item.IdConfiguracao,
        //                    IdController = item.IdController,
        //                    Controller = item.Controller,
        //                    //ViewName = item.Controller,
        //                    //DescricaoTipo = 1,
        //                    //Status = true,
        //                };

        //                this._confingApp.Salvar(dommain);
        //            }

        //            TempData["msgsucesso"] = "Registro salvo com sucesso.";

        //            Session["_locacao_"] = null;
        //        }
        //    }
        //    catch (Exception execption)
        //    {
        //        TempData["msgerror"] = execption.Message.ToString();
        //    }

        //    return View(model);

        //}
        [HttpPost]
        public JsonResult AdicionaCofiguracao(int idController, string controller)
        {
            try
            {


                var objeto = new Configuracao_Models
                {

                    IdController = idController,
                    ControllerAction = controller,

                };

                var lista = new List<Configuracao_Models>();

                if (Session["_locacao_"] != null)
                {
                    lista = (List<Configuracao_Models>)Session["_locacao_"];
                    lista.Add(objeto);
                    Session["_locacao_"] = lista;
                    TempData["msgsucesso"] = "Registro adicionado com sucesso.";
                }
                else
                {
                    lista.Add(objeto);
                    Session["_locacao_"] = lista;
                    TempData["msgsucesso"] = "Registro adicionado com sucesso.";
                }

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        private Configuracao_Models Listas(Configuracao_Models model)
        {
            model.DdlConfiguracaoListaController = ConfiguracaoListaController(_confingApp.ListarTodos());
            //model.DdlConfiguracaoListaControllerPoorFiltro = ConfiguracaoListaControllerPoorFiltro(_confingApp.ListarTodos());

            return model;
        }














        //[HttpPost]
        //public JsonResult AdicionarLocacao(int idLivro, int idPessoa, int idPeriodo, string quantidade)
        //{
        //    try
        //    {
        //        // Listar periodo
        //        var periodo = this._periodoBusiness.ListarPorId(idPeriodo);
        //        // Listar pessoa
        //        var pessoa = this._pessoaBusiness.ListarPorId(idPessoa);
        //        // Listar livro
        //        var livro = this._livroBusiness.ListarPorId(idLivro);

        //        var dataDevolucao = DateTime.Now;

        //        // Calcular devoucao
        //        if (periodo.Chave.ToUpper().Contains("D"))
        //            dataDevolucao = DateTime.Now.AddDays(periodo.Quantidade);
        //        else if (periodo.Chave.ToUpper().Contains("A") || periodo.Descricao.ToUpper().Contains("Ano"))
        //            dataDevolucao = DateTime.Now.AddYears(periodo.Quantidade);
        //        else if (periodo.Chave.ToUpper().Contains("M") || periodo.Descricao.ToUpper().Contains("Mes") || periodo.Descricao.ToUpper().Contains("Mês"))
        //            dataDevolucao = DateTime.Now.AddMonths(periodo.Quantidade);

        //        var objeto = new Configuracao_Models
        //        {
        //            //IdLocacao = Guid.NewGuid().ToString().Replace("-", ""),
        //            //IdConfiguracao = int.Parse().ToString(),
        //            Controller = controller,
        //            ViewName = model.Controller,
        //            //ViewName = model.ViewName,
        //            IdController = model.IdController,
        //            Status = true,
        //            DescricaoTipo = 1,



        //            IdLivro = idLivro,
        //            IdPeriodo = idPeriodo,
        //            IdPessoa = idPessoa,
        //            Quantidade = quantidade,
        //            DataDevolucao = dataDevolucao,
        //            DataLocacao = DateTime.Now,
        //            Periodo = string.Format("{0} - {1}", periodo.Chave.ToLower().Replace("d", "").Replace("m", "").Replace("a", ""), periodo.Descricao),
        //            Responsavel = pessoa.Nome,
        //            Livro = livro.Nome
        //        };

        //        var lista = new List<LocacoesModels>();

        //        if (Session["_locacao_"] != null)
        //        {
        //            lista = (List<LocacoesModels>)Session["_locacao_"];
        //            lista.Add(objeto);
        //            Session["_locacao_"] = lista;
        //            TempData["msgsucesso"] = "Registro adicionado com sucesso.";
        //        }
        //        else
        //        {
        //            lista.Add(objeto);
        //            Session["_locacao_"] = lista;
        //            TempData["msgsucesso"] = "Registro adicionado com sucesso.";
        //        }

        //        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //private LocacoesModels Listas(LocacoesModels model)
        //{
        //    model.DdlPessoa = PessoaLista(this._pessoaBusiness.ListarTodos());
        //    model.DdlPeriodo = PeriodoLista(this._periodoBusiness.ListarTodos());
        //    model.DdlLivro = LivroLista(this._livroBusiness.ListarTodos());
        //    model.DdQauntidade = QauntidadeLista(this._locacaoBusiness.ListarTodos());

        //    return model;
        //}
    }
}
