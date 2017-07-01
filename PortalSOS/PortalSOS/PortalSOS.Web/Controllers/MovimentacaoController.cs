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
    public class MovimentacaoController : BaseController
    {

        private readonly PortalSOS.Application.Movimentacao_Application _movimentacaoApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        private readonly PortalSOS.Application.Produto_Application _produtoApp;
        private readonly PortalSOS.Application.Operacao_Application _operacaoApp;

        public MovimentacaoController()
        {
            this._movimentacaoApp = new Application.Movimentacao_Application();
            this._operacaoApp = new Application.Operacao_Application();
            this._produtoApp = new Application.Produto_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        //
        // GET: /MOvimentacao/
        [CustomAuthorize]
        public ActionResult MovimentacaoLista()
        {
            var model = new List<Movimentacao_Models>();
            foreach (var item in this._movimentacaoApp.ListarTodos())
            {
                var objeto = new Movimentacao_Models
                {
                    IdMovimentacao = item.IdMovimentacao,
                    IdCliente = item.IdCliente,
                    IdProduto = item.IdProduto,
                    IdOperacao = item.IdOperacao,
                    Orcamento = item.Orcamento,
                    Barras = item.Barras,
                    Item = item.Item,
                    Produto = item.Produto,
                    Grupo = item.Grupo,
                    SubGrupo = item.SubGrupo,
                    Linha = item.Linha,
                    Ncm = item.Ncm,
                    Aliq = item.Aliq,
                    RsUnit = item.RsUnit,
                    DescUnit = item.DescUnit,
                    DescPorc = item.DescPorc,
                    RsUnitreal = item.RsUnitreal,
                    Unid = item.Unid,
                    Qtd = item.Qtd,
                    RsTotal = item.RsTotal,
                    RsTotalReal = item.RsTotalReal,
                    CodCli = item.CodCli,
                    CodVeiculo = item.CodVeiculo,
                    Vendedor = item.Vendedor,
                    Tipo = item.Tipo,
                    Data = item.Data,
                    Hora = item.Hora,
                    Usuario = item.Usuario,
                    Unidade = item.Unidade,
                    Status = item.Status,
                    Nf = item.Nf,
                    Promocao = item.Promocao,
                    Caixa = item.Caixa,
                    Turno = item.Turno,
                    AliquestPorc = item.AliquestPorc,
                    Aliqfedporc = item.Aliqfedporc,
                    Aliquestval = item.Aliquestval,
                    Aliqfedval = item.Aliqfedval,
                    Atendente = item.Atendente
                };

                model.Add(objeto);
            }

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult MovimentacaoCreate()

        {
            var model = new Movimentacao_Models();

            model.DdlPessoa = PessoaLista(this._clienteApp.ListarTodos());
            model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());
            model.DdlProduto = ProdutoLista(this._produtoApp.ListarTodos());
            model.DdlMovimentacao = MovimentacaoLista(this._movimentacaoApp.ListarTodos());
            model.DdlOperacao = OperacaoLista(this._operacaoApp.ListarTodos());

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult MovimentacaoCreate(Movimentacao_Models model)
        {
            try
            {
                var dommain = new sosportalmovimentacao_Dommain
                {

                    IdMovimentacao = model.IdMovimentacao,
                    IdCliente = model.IdCliente,
                    IdProduto = model.IdProduto,
                    IdOperacao = model.IdOperacao,
                    Orcamento = model.Orcamento,
                    Barras = model.Barras,
                    Item = model.Item,
                    Produto = model.Produto,
                    Grupo = model.Grupo,
                    SubGrupo = model.SubGrupo,
                    Linha = model.Linha,
                    Ncm = model.Ncm,
                    Aliq = model.Aliq,
                    RsUnit = model.RsUnit,
                    DescUnit = model.DescUnit,
                    DescPorc = model.DescPorc,
                    RsUnitreal = model.RsUnitreal,
                    Unid = model.Unid,
                    Qtd = model.Qtd,
                    RsTotal = model.RsTotal,
                    RsTotalReal = model.RsTotalReal,
                    CodCli = model.CodCli,
                    CodVeiculo = model.CodVeiculo,
                    Vendedor = model.Vendedor,
                    Tipo = model.Tipo,
                    Data = DateTime.Now,
                    Hora = DateTime.Now,
                    Usuario = model.Usuario,
                    Unidade = model.Unidade,
                    Status = model.Status,
                    Nf = model.Nf,
                    Promocao = model.Promocao,
                    Caixa = model.Caixa,
                    Turno = model.Turno,
                    AliquestPorc = model.AliquestPorc,
                    Aliqfedporc = model.Aliqfedporc,
                    Aliquestval = model.Aliquestval,
                    Aliqfedval = model.Aliqfedval,
                    Atendente = model.Atendente,
                };

                if (ModelState.IsValid)
                {
                    this._movimentacaoApp.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro salvo com sucesso!";

                    model.DdlPessoa = PessoaLista(this._clienteApp.ListarTodos());
                    model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());
                    model.DdlProduto = ProdutoLista(this._produtoApp.ListarTodos());
                    model.DdlMovimentacao = MovimentacaoLista(this._movimentacaoApp.ListarTodos());
                    model.DdlOperacao = OperacaoLista(this._operacaoApp.ListarTodos());

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

            var filtro = this._movimentacaoApp.ListarPorId(id);


            var model = new Movimentacao_Models
            {
                IdMovimentacao = filtro.IdMovimentacao,
                IdCliente = filtro.IdCliente,
                IdProduto = filtro.IdProduto,
                IdOperacao = filtro.IdOperacao,
                Orcamento = filtro.Orcamento,
                Barras = filtro.Barras,
                Item = filtro.Item,
                Produto = filtro.Produto,
                Grupo = filtro.Grupo,
                SubGrupo = filtro.SubGrupo,
                Linha = filtro.Linha,
                Ncm = filtro.Ncm,
                Aliq = filtro.Aliq,
                RsUnit = filtro.RsUnit,
                DescUnit = filtro.DescUnit,
                DescPorc = filtro.DescPorc,
                RsUnitreal = filtro.RsUnitreal,
                Unid = filtro.Unid,
                Qtd = filtro.Qtd,
                RsTotal = filtro.RsTotal,
                RsTotalReal = filtro.RsTotalReal,
                CodCli = filtro.CodCli,
                CodVeiculo = filtro.CodVeiculo,
                Vendedor = filtro.Vendedor,
                Tipo = filtro.Tipo,
                //Data = DateTime.Now,
                //Hora = DateTime.Now,
                Usuario = filtro.Usuario,
                Unidade = filtro.Unidade,
                Status = filtro.Status,
                Nf = filtro.Nf,
                Promocao = filtro.Promocao,
                Caixa = filtro.Caixa,
                Turno = filtro.Turno,
                AliquestPorc = filtro.AliquestPorc,
                Aliqfedporc = filtro.Aliqfedporc,
                Aliquestval = filtro.Aliquestval,
                Aliqfedval = filtro.Aliqfedval,
                Atendente = filtro.Atendente

            };

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult Edit(Movimentacao_Models model)
        {
            try
            {
                var filtro = this._movimentacaoApp.ListarPorId(model.IdMovimentacao);


                filtro.IdMovimentacao = model.IdMovimentacao;
                filtro.IdCliente = model.IdCliente;
                filtro.IdProduto = model.IdProduto;
                filtro.IdOperacao = model.IdOperacao;
                filtro.Orcamento = model.Orcamento;
                filtro.Barras = model.Barras;
                filtro.Item = model.Item;
                filtro.Produto = model.Produto;
                filtro.Grupo = model.Grupo;
                filtro.SubGrupo = model.SubGrupo;
                filtro.Linha = model.Linha;
                filtro.Ncm = model.Ncm;
                filtro.Aliq = model.Aliq;
                filtro.RsUnit = model.RsUnit;
                filtro.DescUnit = model.DescUnit;
                filtro.DescPorc = model.DescPorc;
                filtro.RsUnitreal = model.RsUnitreal;
                filtro.Unid = model.Unid;
                filtro.Qtd = model.Qtd;
                filtro.RsTotal = model.RsTotal;
                filtro.RsTotalReal = model.RsTotalReal;
                filtro.CodCli = model.CodCli;
                filtro.CodVeiculo = model.CodVeiculo;
                filtro.Vendedor = model.Vendedor;
                filtro.Tipo = model.Tipo;
                filtro.Usuario = model.Usuario;
                filtro.Unidade = model.Unidade;
                filtro.Status = model.Status;
                filtro.Nf = model.Nf;
                filtro.Promocao = model.Promocao;
                filtro.Caixa = model.Caixa;
                filtro.Turno = model.Turno;
                filtro.AliquestPorc = model.AliquestPorc;
                filtro.Aliqfedporc = model.Aliqfedporc;
                filtro.Aliquestval = model.Aliquestval;
                filtro.Aliqfedval = model.Aliqfedval;
                filtro.Atendente = model.Atendente;


                if (ModelState.IsValid)
                {
                    this._movimentacaoApp.Atualizar(filtro);
                    TempData["msgsucesso"] = "Registro atualizado com sucesso!";

                }


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
            var item = this._movimentacaoApp.ListarPorId(id);

            var model = new Movimentacao_Models

            {
                IdMovimentacao = item.IdMovimentacao,
                IdProduto = item.IdProduto,
                IdOperacao = item.IdOperacao,
                IdCliente = item.IdCliente,
                Orcamento = item.Orcamento,
                Barras = item.Barras,
                Item = item.Item,
                Produto = item.Produto,
                Grupo = item.Grupo,
                SubGrupo = item.SubGrupo,
                Linha = item.Linha,
                Ncm = item.Ncm,
                Aliq = item.Aliq,
                RsUnit = item.RsUnit,
                DescUnit = item.DescUnit,
                DescPorc = item.DescPorc,
                RsUnitreal = item.RsUnitreal,
                Unid = item.Unid,
                Qtd = item.Qtd,
                RsTotal = item.RsTotal,
                RsTotalReal = item.RsTotalReal,
                CodCli = item.CodCli,
                CodVeiculo = item.CodVeiculo,
                Vendedor = item.Vendedor,
                Tipo = item.Tipo,
                Usuario = item.Usuario,
                Unidade = item.Unidade,
                Status = item.Status,
                Nf = item.Nf,
                Promocao = item.Promocao,
                Caixa = item.Caixa,
                Turno = item.Turno,
                AliquestPorc = item.AliquestPorc,
                Aliqfedporc = item.Aliqfedporc,
                Aliquestval = item.Aliquestval,
                Aliqfedval = item.Aliqfedval,
                Atendente = item.Atendente
            };

            model.DdlPessoa = PessoaLista(this._clienteApp.ListarTodos());
            model.DdlProduto = ProdutoLista(this._produtoApp.ListarTodos());
            model.DdlOperacao = OperacaoLista(this._operacaoApp.ListarTodos());
            model.DdlLoja = LojaLista(this._clienteApp.ListarTodos());

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult Excluir(int id)
        {
            try
            {
                this._movimentacaoApp.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("index", "movimentacao");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("index", "movimentacao");
            }
        }


    }
}
