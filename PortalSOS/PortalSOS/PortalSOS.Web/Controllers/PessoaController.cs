using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalSOS.Web.Controllers
{
    public class PessoaController : BaseController
    {
        //private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        //private readonly PortalSOS.Application.Perfil_Application _PerfilApp;
        //private readonly PortalSOS.Application.Loja_Application _lojaApp;
        //public PessoaController()
        //{
        //    this._clienteApp = new Application.Cliente_Application();
        //    this._PerfilApp = new Application.Perfil_Application();
        //    this._lojaApp = new Application.Loja_Application();
        //}
        ////
        //// GET: /Pessoa/

        //public ActionResult Index()
        //{

        //    var model = new List<Cliente_Models>();

        //    foreach (var item in this._clienteApp.ListarTodos())
        //    {
        //        var objeto = new Cliente_Models
        //        {

        //            IdCliente = item.IdCliente,
        //            CodProduto = item.CodProduto,
        //            IdConfiguracaoCliente = item.IdConfiguracaoCliente,
        //            IdContato = item.IdContato,
        //            IdEndereco = item.IdEndereco,
        //            InscricaoMunicipal = item.InscricaoMunicipal,
        //            RazaoSocial = item.RazaoSocial,
        //            RG = item.RG,
        //            Cnae = item.Cnae,
        //            CPF = item.CPF,
        //            Senha = item.Senha,
        //            Ativacao = item.Ativacao,
        //            Cnpj = item.Cnpj,
        //            Email = item.Email,
        //            Emitente = item.Emitente,
        //            Estadual = item.Estadual,
        //            IdPerfil = item.IdPerfil,
        //            Licenca = item.Licenca,
        //            LimiteCred = item.LimiteCred,
        //            Modelo = item.Modelo,
        //            Obs = item.Obs,
        //            Pessoa = item.Pessoa,
        //            Representante = item.Representante,
        //            Status = item.Status,
        //            Tipo = item.Tipo,
        //            Total = item.Total,
        //            Ultilizado = item.Ultilizado,



        //        };

        //        model.Add(objeto);
        //    }

        //    return View(model);
        //    //return View(this._pessoaApp.ListarTodos());
        //}
        //public ActionResult Create()
        //{
        //    var model = new Pessoa_Models();

        //    model.DdlPerfil = PerfilLista(this._PerfilApp.ListarTodos());
        //    model.DdlCnpj = CnpjLista(this._clienteApp.ListarTodos());

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Create(Cliente_Models model)
        //{

        //    if (this._clienteApp.Existe(model.CPF))
        //    {
        //        TempData["msgsucesso"] = "CPF já cadastrado!";
        //        return View(model);

        //    }
        //    if (configuration.ValidationCPF.IsCpf(model.CPF))
        //    {
        //        try
        //        {
        //            var dto = new sosportalcliente_Dommain
        //            {
        //                IdCliente = model.IdCliente,
        //                CodProduto = model.CodProduto,
        //                IdConfiguracaoCliente = model.IdConfiguracaoCliente,
        //                IdContato = model.IdContato,
        //                IdEndereco = model.IdEndereco,
        //                InscricaoMunicipal = model.InscricaoMunicipal,
        //                RazaoSocial = model.RazaoSocial,
        //                RG = model.RG,
        //                Cnae = model.Cnae,
        //                CPF = model.CPF,
        //                Senha = model.Senha,
        //                Ativacao = model.Ativacao,
        //                Cnpj = model.Cnpj,
        //                Email = model.Email,
        //                Emitente = model.Emitente,
        //                Estadual = model.Estadual,
        //                IdPerfil = model.IdPerfil,
        //                Licenca = model.Licenca,
        //                LimiteCred = model.LimiteCred,
        //                Modelo = model.Modelo,
        //                Obs = model.Obs,
        //                Pessoa = model.Pessoa,
        //                Representante = model.Representante,
        //                Status = model.Status,
        //                Tipo = model.Tipo,
        //                Total = model.Total,
        //                Ultilizado = model.Ultilizado,
        //            };

        //            if (ModelState.IsValid)
        //            {
        //                this._clienteApp.Salvar(dto);
        //                TempData["msgsucesso"] = "Registro salvo com sucesso";

        //                model.DdlPerfil = PerfilLista(this._PerfilApp.ListarTodos());
        //                model.DdlCnpj = CnpjLista(this._lojaApp.ListarTodos());
        //            }

        //        }
        //        catch (Exception exception)
        //        {

        //            TempData["msgerror"] = exception.Message.ToString();
        //            return View(model);
        //        }

        //    }

        //    else
        //    {
        //        TempData["msgerror"] = "Cpf invalido!";
        //    }

        //    return RedirectToAction("create");

        //}
        //public ActionResult Edit(int id)
        //{

        //    var filtro = this._pessoaApp.ListarPorId(id);


        //    var model = new Pessoa_Models
        //    {
        //        IdPessoa = filtro.IdPessoa,
        //        IdPerfil = filtro.IdPerfil,
        //        IdLoja = filtro.IdLoja,
        //        Pessoa = filtro.Pessoa,
        //        Razao = filtro.Razao,
        //        InscMunicipal = filtro.InscMunicipal,
        //        Cnpj = filtro.Cnpj,
        //        Estadual = filtro.Estadual,
        //        Endereco = filtro.Endereco,
        //        N = filtro.N,
        //        Compl = filtro.Compl,
        //        Bairro = filtro.Bairro,
        //        CodMunicipio = filtro.CodMunicipio,
        //        Municipio = filtro.Municipio,
        //        Cnae = filtro.Cnae,
        //        Email = filtro.Email,
        //        Cep = filtro.Cep,
        //        Uf = filtro.Uf,
        //        Telefone = filtro.Telefone,
        //        // Perfil = filtro.Perfil,
        //        TipodeTel = filtro.TipodeTel,
        //        TipoEnd = filtro.TipoEnd,
        //        Operadora = filtro.Operadora,
        //        Contato = filtro.Contato,
        //        CodVenda = filtro.CodVenda,
        //        Licenca = filtro.Licenca,
        //        Ativacao = filtro.Ativacao,
        //        Total = filtro.Total,
        //        Obs = filtro.Obs,
        //        LimiteCred = filtro.LimiteCred,
        //        Status = filtro.Status,
        //        Emitente = filtro.Emitente,
        //        Serie = filtro.Serie,
        //        Classificacao = filtro.Classificacao,
        //        CPF = filtro.CPF,
        //        Tipo = filtro.Tipo,
        //        Representante = filtro.Representante,
        //        Ultilizado = filtro.Ultilizado,
        //        Senha = filtro.Senha,


        //    };

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Edit(Pessoa_Models model)
        //{
        //    try
        //    {
        //        var filtro = this._pessoaApp.ListarPorId(model.IdPessoa);

        //        filtro.IdPessoa = model.IdPessoa;
        //        filtro.IdPerfil = model.IdPerfil;
        //        filtro.IdLoja = model.IdLoja;
        //        filtro.Pessoa = model.Pessoa;
        //        filtro.Razao = model.Razao;
        //        filtro.InscMunicipal = model.InscMunicipal;
        //        filtro.Cnpj = model.Cnpj;
        //        filtro.Estadual = model.Estadual;
        //        filtro.Endereco = model.Endereco;
        //        filtro.N = model.N;
        //        filtro.Compl = model.Compl;
        //        filtro.Bairro = model.Bairro;
        //        filtro.CodMunicipio = model.CodMunicipio;
        //        filtro.Municipio = model.Municipio;
        //        filtro.Cnae = model.Cnae;
        //        filtro.Email = model.Email;
        //        filtro.Cep = model.Cep;
        //        filtro.Uf = model.Uf;
        //        filtro.Telefone = model.Telefone;
        //        // filtro.Perfil = model.Perfil;
        //        filtro.TipodeTel = model.TipodeTel;
        //        filtro.TipoEnd = model.TipoEnd;
        //        filtro.Operadora = model.Operadora;
        //        filtro.Contato = model.Contato;
        //        filtro.CodVenda = model.CodVenda;
        //        filtro.Licenca = model.Licenca;
        //        filtro.Ativacao = model.Ativacao;
        //        filtro.Total = model.Total;
        //        filtro.Obs = model.Obs;
        //        filtro.LimiteCred = model.LimiteCred;
        //        filtro.Status = model.Status;
        //        filtro.Emitente = model.Emitente;
        //        filtro.Modelo = model.Modelo;
        //        filtro.Serie = model.Serie;
        //        filtro.Classificacao = model.Classificacao;
        //        filtro.CPF = model.CPF;
        //        filtro.Tipo = model.Tipo;
        //        filtro.Representante = model.Representante;
        //        filtro.Ultilizado = model.Ultilizado;
        //        filtro.Senha = model.Senha;

        //        if (ModelState.IsValid)
        //        {
        //            this._pessoaApp.Atualizar(filtro);
        //            TempData["msgsucesso"] = "Registro atualizado com sucesso!";

        //        }


        //        return View(model);
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return View(model);
        //    }
        //}

        //public ActionResult Details(int id)
        //{
        //    var filtro = this._pessoaApp.ListarPorId(id);

        //    var model = new Pessoa_Models

        //    {

        //        IdPessoa = filtro.IdPessoa,
        //        IdPerfil = filtro.IdPerfil,
        //        IdLoja = filtro.IdLoja,
        //        Pessoa = filtro.Pessoa,
        //        Razao = filtro.Razao,
        //        InscMunicipal = filtro.InscMunicipal,
        //        Cnpj = filtro.Cnpj,
        //        Estadual = filtro.Estadual,
        //        Endereco = filtro.Endereco,
        //        N = filtro.N,
        //        Compl = filtro.Compl,
        //        Bairro = filtro.Bairro,
        //        CodMunicipio = filtro.CodMunicipio,
        //        Municipio = filtro.Municipio,
        //        Cnae = filtro.Cnae,
        //        Email = filtro.Email,
        //        Cep = filtro.Cep,
        //        Uf = filtro.Uf,
        //        Telefone = filtro.Telefone,
        //        // Perfil = filtro.Perfil,
        //        TipodeTel = filtro.TipodeTel,
        //        TipoEnd = filtro.TipoEnd,
        //        Operadora = filtro.Operadora,
        //        Contato = filtro.Contato,
        //        CodVenda = filtro.CodVenda,
        //        Licenca = filtro.Licenca,
        //        Ativacao = filtro.Ativacao,
        //        Total = filtro.Total,
        //        Obs = filtro.Obs,
        //        LimiteCred = filtro.LimiteCred,
        //        Status = filtro.Status,
        //        Emitente = filtro.Emitente,
        //        Serie = filtro.Serie,
        //        Classificacao = filtro.Classificacao,
        //        CPF = filtro.CPF,
        //        Tipo = filtro.Tipo,
        //        Representante = filtro.Representante,
        //        Ultilizado = filtro.Ultilizado,
        //        Senha = filtro.Senha,
        //    };

        //    model.DdlPerfil = PerfilLista(this._PerfilApp.ListarTodos());
        //    model.DdlLoja = LojaLista(this._lojaApp.ListarTodos());

        //    return View(model);
        //}

        //public ActionResult Excluir(int id)
        //{
        //    try
        //    {
        //        this._pessoaApp.Excluir(id);
        //        TempData["msgsucesso"] = "Registro excluido com sucesso!";

        //        return RedirectToAction("index", "pessoa");

        //    }

        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return RedirectToAction("index", "pessoa");
        //    }
        //}


    }
}
