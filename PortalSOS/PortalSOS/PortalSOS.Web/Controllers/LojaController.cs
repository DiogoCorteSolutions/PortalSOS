using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortalSOS.Web.Controllers
{
    public class LojaController : BaseController
    {

        //private readonly PortalSOS.Application.Loja_Application _lojaApp;

        //public LojaController()
        //{
        //    this._lojaApp = new Application.Loja_Application();
        //}
        //
        // GET: /Loja/

        //public ActionResult Index()
        //{
        //    var model = new List<Loja_Models>();

        //    foreach (var item in this._lojaApp.ListarTodos())
        //    {
        //        var objeto = new Loja_Models
        //        {

        //            IdLoja = item.IdLoja,
        //            Cnpj = item.Cnpj,
        //            CPF = item.CPF,
        //            NomeFantasia = item.NomeFantasia,
        //            Telefone = item.Telefone,
        //            //Datacadastro = item.Datacadastro,
        //            Endereco = item.Endereco,
        //            Complemento = item.Complemento,
        //            Numero = item.Numero,
        //            Cep = item.Cep,
        //            Status = item.Status,
        //            ResponsavelCadastro = item.ResponsavelCadastro,
        //            Senha = item.Senha,
        //            PerfilLoja = item.PerfilLoja
        //        };

        //        model.Add(objeto);
        //    }

        //    return View(model);
        //}

        //public ActionResult Create()
        //{
        //    var model = new Loja_Models();
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult Create(Loja_Models model)
        //{
        //    try
        //    {
        //        var dommain = new sosportalloja_Dommain
        //        {

        //            IdLoja = model.IdLoja,
        //            Cnpj = model.Cnpj,
        //            CPF = model.CPF,
        //            NomeFantasia = model.NomeFantasia,
        //            Telefone = model.Telefone,
        //            Endereco = model.Endereco,
        //            Complemento = model.Complemento,
        //            Numero = model.Numero,
        //            Cep = model.Cep,
        //            Status = model.Status,
        //            ResponsavelCadastro = model.ResponsavelCadastro,
        //            Datacadastro = DateTime.Now,
        //            // PerfilLoja = "Loja",
        //            Senha = model.Senha,


        //        };

        //        if (ModelState.IsValid)
        //        {
        //            this._lojaApp.Salvar(dommain);
        //            TempData["msgsucesso"] = "Registro salvo com sucesso!";

        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return View(model);
        //        throw;
        //    }

        //    return RedirectToAction("Create");
        //}

        //public ActionResult Edit(int id)
        //{

        //    var filtro = this._lojaApp.ListarPorId(id);


        //    var model = new Loja_Models
        //    {
        //        IdLoja = filtro.IdLoja,
        //        Cnpj = filtro.Cnpj,
        //        CPF = filtro.CPF,
        //        NomeFantasia = filtro.NomeFantasia,
        //        Telefone = filtro.Telefone,
        //        Endereco = filtro.Endereco,
        //        Complemento = filtro.Complemento,
        //        Numero = filtro.Numero,
        //        Cep = filtro.Cep,
        //        Status = filtro.Status,
        //        ResponsavelCadastro = filtro.ResponsavelCadastro,
        //        Senha = filtro.Senha,
        //        PerfilLoja = filtro.PerfilLoja

        //    };

        //    return View(model);
        //}
        //[HttpPost]
        //public ActionResult Edit(Loja_Models model)
        //{
        //    try
        //    {
        //        var filtro = this._lojaApp.ListarPorId(model.IdLoja);

        //        filtro.IdLoja = model.IdLoja;
        //        filtro.Cnpj = model.Cnpj;
        //        filtro.CPF = model.CPF;
        //        filtro.NomeFantasia = model.NomeFantasia;
        //        filtro.Telefone = model.Telefone;
        //        filtro.Endereco = model.Endereco;
        //        filtro.Complemento = model.Complemento;
        //        filtro.Numero = model.Numero;
        //        filtro.Cep = model.Cep;
        //        filtro.Status = model.Status;
        //        filtro.ResponsavelCadastro = model.ResponsavelCadastro;
        //        filtro.Senha = model.Senha;
        //        filtro.PerfilLoja = "Loja";

        //        if (ModelState.IsValid)
        //        {
        //            this._lojaApp.Atualizar(filtro);
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
        //    var filtro = this._lojaApp.ListarPorId(id);

        //    var model = new Loja_Models

        //    {

        //        IdLoja = filtro.IdLoja,
        //        Cnpj = filtro.Cnpj,
        //        CPF = filtro.CPF,
        //        NomeFantasia = filtro.NomeFantasia,
        //        Telefone = filtro.Telefone,
        //        //Datacadastro = item.Datacadastro,
        //        Endereco = filtro.Endereco,
        //        Complemento = filtro.Complemento,
        //        Numero = filtro.Numero,
        //        Cep = filtro.Cep,
        //        Status = filtro.Status,
        //        ResponsavelCadastro = filtro.ResponsavelCadastro,
        //        Senha = filtro.Senha,
        //        PerfilLoja = filtro.PerfilLoja
        //    };


        //    model.DdlLoja = LojaLista(this._lojaApp.ListarTodos());

        //    return View(model);
        //}

        //public ActionResult Excluir(int id)
        //{
        //    try
        //    {
        //        this._lojaApp.Excluir(id);
        //        TempData["msgsucesso"] = "Registro excluido com sucesso!";

        //        return RedirectToAction("index", "loja");

        //    }

        //    catch (Exception exception)
        //    {
        //        TempData["msgerror"] = exception.Message.ToString();
        //        return RedirectToAction("index", "loja");
        //    }
        //}
    }
}
