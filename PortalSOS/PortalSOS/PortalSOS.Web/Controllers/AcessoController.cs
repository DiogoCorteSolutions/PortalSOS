using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCheckBoxList.Model;
using Newtonsoft.Json;
using PortalSOS.Web.Helpers;

namespace PortalSOS.Web.Controllers
{
    //[CustomAuthorize]
    public class AcessoController : BaseController
    {
        private readonly PortalSOS.Application.AcessoApplication _acessoApp;
        private readonly PortalSOS.Application.Perfil_Application _perfilApp;
        private readonly PortalSOS.Application.Cofiguracao_Application _configuracaApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        public AcessoController()
        {
            this._acessoApp = new Application.AcessoApplication();
            this._perfilApp = new Application.Perfil_Application();
            this._configuracaApp = new Application.Cofiguracao_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //GET: /Base/


        // GET: /MOvimentacao/
        //[CustomAuthorize]
        public ActionResult AcessoLista()
        {
            var model = new List<ConfiguracaoCliente_Models>();

            foreach (var item in this._acessoApp.ListarTodos())
            {
                var objeto = new ConfiguracaoCliente_Models
                {
                    IdConfiguracao = item.IdConfiguracao,
                    IdCliente = item.IdCliente,
                    IdPerfil = item.IdPerfil,
                    Status = item.Status,
                    IdPessoaLoja = item.IdPessoaLoja,
                    TipoPerfil = item.TipoPerfil,
                    TipoPessoa = item.TipoPessoa
                };

                model.Add(objeto);
            }

            return View(model);
        }
        //[CustomAuthorize]
        public ActionResult AcessoCreate()

        {
            var model = new ConfiguracaoCliente_Models();



            model.DdlConfiguracaoListaView = ConfiguracaoListaView(_configuracaApp.ListarTodos());
            model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());

            return View(model);
        }
        //[HttpPost, CustomAuthorize]
        [HttpPost]
        public ActionResult AcessoCreate(ConfiguracaoCliente_Models model)
        {
            var PerfilPai = model.IdCliente;

            var result = new ResultConfiguracaoModels();
            try
            {

                model.DdlConfiguracaoListaView = ConfiguracaoListaView(_configuracaApp.ListarTodos());
                model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
                model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());


                var fitro = this._clienteApp.ListarPorCpf(GetLogin).IdCliente;
                var filtroPai = this._clienteApp.ListarPorCpf(GetLogin).IdPessoaLoja;

                var dommain = new sosportalconfiguracaocliente_Dommain
                {

                    IdConfiguracao = model.IdConfiguracao,
                    IdCliente = fitro,
                    IdPerfil = model.IdPerfil,
                    IdConfiguracaoCliente = model.IdConfiguracaoCliente,
                    Status = model.Status,
                    IdPessoaLoja = fitro,
                    TipoPessoa = 1,
                    TipoPerfil = 1,
                };

                if (ModelState.IsValid)
                {
                    this._acessoApp.Salvar(dommain);

                    foreach (var item in model.ListIds)
                    {
                        var dommains = new sosportalconfiguracaocliente_Dommain
                        {
                            IdConfiguracaoCliente = model.IdConfiguracaoCliente,
                            IdConfiguracao = item,
                            IdCliente = fitro,
                            IdPerfil = model.IdPerfil,
                            Status = model.Status,
                            IdPessoaLoja = fitro,
                            TipoPessoa = 1,
                            TipoPerfil = 1,
                        };
                        this._acessoApp.Salvar(dommains);
                    }
                    model.DdlConfiguracaoListaView = ConfiguracaoListaView(_configuracaApp.ListarTodos());
                    model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
                    model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());

                    result.message = "Registro salvo com sucesso!";
                    result.data = dommain;

                    return Json(new { success = true, result = result }, JsonRequestBehavior.AllowGet);


                    //model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
                    //model.DdlConfiguracaoListaControllerPoorFiltro = ConfiguracaoListaControllerPoorFiltro(this._configuracaApp.ListarTodos());
                    //model.DdlConfiguracaoListaIndePorIdController = ConfiguracaoListaIndePorIdController(this._configuracaApp.ListarTodos());
                    //model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());

                }
            }
            catch (Exception exception)
            {
                result.message = exception.Message.ToString();
                return Json(new { success = false, result = result }, JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("AcessoCreate");
        }
        [HttpPost]
        public JsonResult BuscarActions(string id)
        {
            var data = this._configuracaApp.ListarActioPorIdController(int.Parse(id)).ToList();// ""; // buscar lista de action por id conrolle

            var result = new List<sosportalconfiguracaoModels>();
            foreach (var item in data)
            {
                result.Add(new sosportalconfiguracaoModels
                {
                    ControllerAction = item.ControllerAction,
                    DescricaoTipo = item.DescricaoTipo,
                    IdConfiguracao = item.IdConfiguracao,
                    IdController = item.IdController,
                    Status = item.Status.HasValue ? item.Status.Value : false,
                    ViewName = item.ViewName,
                });
            }
            return Json(new { success = true, result = result }, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Create()
        //{
        //    var model = new ConfiguracaoCliente_Models();
        //    this.Listas(model);

        //    return View(model);
        //}

        //[HttpPost]

        //public ActionResult Create(ConfiguracaoCliente_Models model)
        //{
        //    try
        //    {
        //        this.Listas(model);

        //        if (Session["_locacao_"] != null)
        //        {
        //            var lista = (List<ConfiguracaoCliente_Models>)Session["_locacao_"];

        //            foreach (var item in lista)
        //            {
        //                var dto = new sosportalconfiguracaocliente_Dommain
        //                {
        //                    Id = item.Id,
        //                    IdPeriodo = item.IdPeriodo,
        //                    IdLivro = item.IdLivro,
        //                    IdPessoa = item.IdPessoa,
        //                    DataLocacao = item.DataLocacao,
        //                    DataDevolucao = item.DataDevolucao,
        //                    Quantidade = item.Quantidade,
        //                    Tempo = item.Tempo
        //                };

        //                this._locacaoBusiness.Salvar(dto);
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

        //        var objeto = new LocacoesModels
        //        {
        //            IdLocacao = Guid.NewGuid().ToString().Replace("-", ""),
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
        private ConfiguracaoCliente_Models Listas(ConfiguracaoCliente_Models model)
        {
            model.DdlConfiguracaoListaView = ConfiguracaoListaView(_configuracaApp.ListarTodos());

            model.DdlConfiguracaoListaController = ConfiguracaoListaController(this._configuracaApp.ListarTodos());
            model.DdlConfiguracaoListaControllerPoorFiltro = ConfiguracaoListaControllerPoorFiltro(this._configuracaApp.ListarTodos());
            model.DdlConfiguracaoListaIndePorIdController = ConfiguracaoListaIndePorIdController(this._configuracaApp.ListarTodos());

            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlControllerlLista = ConfiguracaoLista(this._configuracaApp.ListarTodos().ToList().Where(x => x.IdController != 0));
            model.DdlConfiguracaoListaControlerView = ConfiguracaoListaControlerView(this._configuracaApp.ListarTodos());

            return model;
        }
        public ActionResult Edit(ConfiguracaoCliente_Models model)
        {
            var filtro = this._acessoApp.ListarPorId(model.IdConfiguracaoCliente);
            model.IdPerfil = filtro.IdPerfil;
            model.IdConfiguracao = filtro.IdConfiguracao;
            return View();
        }
        //public ActionResult Excluir(int id)
        //{
        //    try
        //    {
        //        this._acessoApp.Excluir(id);
        //        TempData["msgsucesso"] = "Registro excluido com sucesso!";

        //        return RedirectToAction("Acesso", "PaginaAcessoCreate");
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = "Não foi possivel excluir o registro!";
        //        return RedirectToAction("Acesso", "PaginaAcessoCreate");
        //    }
        //}

    }
}
