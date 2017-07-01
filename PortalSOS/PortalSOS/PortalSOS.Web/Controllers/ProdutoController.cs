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
    public class ProdutoController : BaseController
    {
        private readonly PortalSOS.Application.Perfil_Application _perfil;
        private readonly PortalSOS.Application.Produto_Application _produtoApp;

        public ProdutoController()
        {
            this._produtoApp = new Application.Produto_Application();
            this._perfil = new Application.Perfil_Application();
        }
        //
        // GET: /Produto/        
        [CustomAuthorize]
        public ActionResult ProdutoLista()
        {
            var model = new List<Produto_Models>();

            foreach (var item in this._produtoApp.ListarTodos())
            {
                var objeto = new Produto_Models
                {
                    IdProduto = item.IdProduto,
                    IdPerfil = item.IdPerfil,
                    Atualizado = DateTime.Now,
                    Barras = item.Barras,
                    Ref = item.Ref,
                    Forn = item.Forn,
                    Cfop = item.Cfop,
                    Prod = item.Prod,
                    Unidade = item.Unidade,
                    CodGen = item.CodGen,
                    Gen = item.Gen,
                    Sub = item.Sub,
                    Linha = item.Linha,
                    ValidDias = item.ValidDias,
                    ValidData = item.ValidData,
                    Lote = item.Lote,
                    Cor = item.Cor,
                    Tipo = item.Tipo,
                    Atual = item.Atual,
                    Minimo = item.Minimo,
                    Ideial = item.Ideial,
                    Bruto = item.Bruto,
                    Ucom = item.Ucom,
                    Ncm = item.Ncm,
                    Utrib = item.Utrib,
                    Ubal = item.Ubal,
                    Validade = item.Validade,
                    Ali = item.Ali,
                    Stat = item.Stat,
                    Cust = item.Cust,
                    Descricao = item.Descricao,
                    Subtri = item.Subtri,
                    Ipi = item.Ipi,
                    Dificms = item.Dificms,
                    Custoimp = item.Custoimp,
                    Comissadi = item.Comissadi,
                    Mgven = item.Mgven,
                    Varejo = item.Varejo,
                    Atacado = item.Atacado,
                    Mgvenajus = item.Mgvenajus,
                    Vavtot = item.Vavtot,
                    Imagem = item.Imagem,
                    Tam = item.Tam,
                    Flex = item.Flex,
                    AlisetPorc = item.AlisetPorc,
                    Aliestval = item.Aliestval,
                    AlifedPorc = item.AlifedPorc,
                    Alifedval = item.Alifedval,
                    desccncm = item.desccncm
                };

                model.Add(objeto);
            }

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult ProdutoCreate()
        {
            var model = new Produto_Models();

            model.DdlPerfil = PerfilLista(this._perfil.ListarTodos());


            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult ProdutoCreate(Produto_Models model)
        {
            try
            {
                var dommain = new sosportalproduto_Dommain
                {
                    IdProduto = model.IdProduto,
                    IdPerfil = model.IdPerfil,
                    Atualizado = DateTime.Now,
                    Barras = model.Barras,
                    Ref = model.Ref,
                    Forn = model.Forn,
                    Cfop = model.Cfop,
                    Prod = model.Prod,
                    Unidade = model.Unidade,
                    CodGen = model.CodGen,
                    Gen = model.Gen,
                    Sub = model.Sub,
                    Linha = model.Linha,
                    ValidDias = model.ValidDias,
                    ValidData = DateTime.Now,
                    Lote = model.Lote,
                    Cor = model.Cor,
                    Tipo = model.Tipo,
                    Atual = model.Atual,
                    Minimo = model.Minimo,
                    Ideial = model.Ideial,
                    Bruto = model.Bruto,
                    Ucom = model.Ucom,
                    Ncm = model.Ncm,
                    Utrib = model.Utrib,
                    Ubal = model.Ubal,
                    Validade = model.Validade,
                    Ali = model.Ali,
                    Stat = model.Stat,
                    Cust = model.Cust,
                    Descricao = model.Descricao,
                    Subtri = model.Subtri,
                    Ipi = model.Ipi,
                    Dificms = model.Dificms,
                    Custoimp = model.Custoimp,
                    Comissadi = model.Comissadi,
                    Mgven = model.Mgven,
                    Varejo = model.Varejo,
                    Atacado = model.Atacado,
                    Mgvenajus = model.Mgvenajus,
                    Vavtot = model.Vavtot,
                    Imagem = model.Imagem,
                    Tam = model.Tam,
                    Flex = model.Flex,
                    AlisetPorc = model.AlisetPorc,
                    Aliestval = model.Aliestval,
                    AlifedPorc = model.AlifedPorc,
                    Alifedval = model.Alifedval,
                    desccncm = model.desccncm

                };

                if (ModelState.IsValid)
                {
                    this._produtoApp.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro salvo com sucesso!";

                }
            }
            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
                throw;
            }

            return RedirectToAction("Create");
        }
        [CustomAuthorize]
        public ActionResult Edit(int id)
        {

            var filtro = this._produtoApp.ListarPorId(id);


            var model = new Produto_Models
            {
                IdProduto = filtro.IdProduto,
                IdPerfil = filtro.IdPerfil,
                Atualizado = filtro.Atualizado,
                Barras = filtro.Barras,
                Ref = filtro.Ref,
                Forn = filtro.Forn,
                Cfop = filtro.Cfop,
                Prod = filtro.Prod,
                Unidade = filtro.Unidade,
                CodGen = filtro.CodGen,
                Gen = filtro.Gen,
                Sub = filtro.Sub,
                Linha = filtro.Linha,
                ValidDias = filtro.ValidDias,
                ValidData = filtro.ValidData,
                Lote = filtro.Lote,
                Cor = filtro.Cor,
                Tipo = filtro.Tipo,
                Atual = filtro.Atual,
                Minimo = filtro.Minimo,
                Ideial = filtro.Ideial,
                Bruto = filtro.Bruto,
                Ucom = filtro.Ucom,
                Ncm = filtro.Ncm,
                Utrib = filtro.Utrib,
                Ubal = filtro.Ubal,
                Validade = filtro.Validade,
                Ali = filtro.Ali,
                Stat = filtro.Stat,
                Cust = filtro.Cust,
                Descricao = filtro.Descricao,
                Subtri = filtro.Subtri,
                Ipi = filtro.Ipi,
                Dificms = filtro.Dificms,
                Custoimp = filtro.Custoimp,
                Comissadi = filtro.Comissadi,
                Mgven = filtro.Mgven,
                Varejo = filtro.Varejo,
                Atacado = filtro.Atacado,
                Mgvenajus = filtro.Mgvenajus,
                Vavtot = filtro.Vavtot,
                Imagem = filtro.Imagem,
                Tam = filtro.Tam,
                Flex = filtro.Flex,
                AlisetPorc = filtro.AlisetPorc,
                Aliestval = filtro.Aliestval,
                AlifedPorc = filtro.AlifedPorc,
                Alifedval = filtro.Alifedval,
                desccncm = filtro.desccncm

            };

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult Edit(Produto_Models model)
        {
            try
            {
                var filtro = this._produtoApp.ListarPorId(model.IdProduto);

                filtro.IdProduto = model.IdProduto;
                filtro.IdPerfil = model.IdPerfil;
                filtro.Atualizado = DateTime.Now;
                filtro.Barras = model.Barras;
                filtro.Ref = model.Ref;
                filtro.Forn = model.Forn;
                filtro.Cfop = model.Cfop;
                filtro.Prod = model.Prod;
                filtro.Unidade = model.Unidade;
                filtro.CodGen = model.CodGen;
                filtro.Gen = model.Gen;
                filtro.Sub = model.Sub;
                filtro.Linha = model.Linha;
                filtro.ValidDias = model.ValidDias;
                filtro.ValidData = filtro.ValidData;
                filtro.Lote = model.Lote;
                filtro.Cor = model.Cor;
                filtro.Tipo = model.Tipo;
                filtro.Atual = model.Atual;
                filtro.Minimo = model.Minimo;
                filtro.Ideial = model.Ideial;
                filtro.Bruto = model.Bruto;
                filtro.Ucom = model.Ucom;
                filtro.Ncm = model.Ncm;
                filtro.Utrib = model.Utrib;
                filtro.Ubal = model.Ubal;
                filtro.Validade = model.Validade;
                filtro.Ali = model.Ali;
                filtro.Stat = model.Stat;
                filtro.Cust = model.Cust;
                filtro.Descricao = model.Descricao;
                filtro.Subtri = model.Subtri;
                filtro.Ipi = model.Ipi;
                filtro.Dificms = model.Dificms;
                filtro.Custoimp = model.Custoimp;
                filtro.Comissadi = model.Comissadi;
                filtro.Mgven = model.Mgven;
                filtro.Varejo = model.Varejo;
                filtro.Atacado = model.Atacado;
                filtro.Mgvenajus = model.Mgvenajus;
                filtro.Vavtot = model.Vavtot;
                filtro.Imagem = model.Imagem;
                filtro.Tam = model.Tam;
                filtro.Flex = model.Flex;
                filtro.AlisetPorc = model.AlisetPorc;
                filtro.Aliestval = model.Aliestval;
                filtro.AlifedPorc = model.AlifedPorc;
                filtro.Alifedval = model.Alifedval;
                filtro.desccncm = model.desccncm;

                if (ModelState.IsValid)
                {
                    this._produtoApp.Atualizar(filtro);
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
            var item = this._produtoApp.ListarPorId(id);

            var model = new Produto_Models

            {

                IdProduto = item.IdProduto,
                IdPerfil = item.IdPerfil,
                Atualizado = DateTime.Now,
                Barras = item.Barras,
                Ref = item.Ref,
                Forn = item.Forn,
                Cfop = item.Cfop,
                Prod = item.Prod,
                Unidade = item.Unidade,
                CodGen = item.CodGen,
                Gen = item.Gen,
                Sub = item.Sub,
                Linha = item.Linha,
                ValidDias = item.ValidDias,
                ValidData = item.ValidData,
                Lote = item.Lote,
                Cor = item.Cor,
                Tipo = item.Tipo,
                Atual = item.Atual,
                Minimo = item.Minimo,
                Ideial = item.Ideial,
                Bruto = item.Bruto,
                Ucom = item.Ucom,
                Ncm = item.Ncm,
                Utrib = item.Utrib,
                Ubal = item.Ubal,
                Validade = item.Validade,
                Ali = item.Ali,
                Stat = item.Stat,
                Cust = item.Cust,
                Descricao = item.Descricao,
                Subtri = item.Subtri,
                Ipi = item.Ipi,
                Dificms = item.Dificms,
                Custoimp = item.Custoimp,
                Comissadi = item.Comissadi,
                Mgven = item.Mgven,
                Varejo = item.Varejo,
                Atacado = item.Atacado,
                Mgvenajus = item.Mgvenajus,
                Vavtot = item.Vavtot,
                Imagem = item.Imagem,
                Tam = item.Tam,
                Flex = item.Flex,
                AlisetPorc = item.AlisetPorc,
                Aliestval = item.Aliestval,
                AlifedPorc = item.AlifedPorc,
                Alifedval = item.Alifedval,
                desccncm = item.desccncm
            };

            model.DdlPerfil = PerfilLista(this._perfil.ListarTodos());

            return View(model);
        }
         [CustomAuthorize]
        public ActionResult Excluir(int id)
        {
            try
            {
                this._produtoApp.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("index", "produto");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("index", "produto");
            }
        }
    }

}
