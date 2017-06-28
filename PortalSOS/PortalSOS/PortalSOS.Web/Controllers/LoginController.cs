using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortalSOS.Web.Helpers;
using Biblioteca_PIM.InfraStructre;

namespace PortalSOS.Web.Controllers
{
    public class LoginController : BaseController
    {
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;

        public LoginController()
        {
            this._clienteApp = new Application.Cliente_Application();

        }
        //
        // GET: /Login/
        public ActionResult Index()
        {
            return View(new sosportalcliente_Dommain());
        }

        [HttpPost]
        public ActionResult Index(sosportalcliente_Dommain dommain)
        {
            cpf(dommain.CPF);

            dommain.CPF = StringHelper.FormatarCpf(dommain.CPF);

            var retorno = this._clienteApp.Login(dommain.CPF, dommain.Senha);

            if (retorno != null)
            {
                

                var setidloja = _clienteApp.ListarPorCpf(dommain.CPF).IdCliente;
                var setidlojaIdLoja = _clienteApp.ListarPorCpf(dommain.CPF).IdPessoaLoja;
                var setidPerfil = _clienteApp.ListarPorCpf(dommain.CPF).IdPerfil;
                //var setidloja = _clienteApp.ListarPorCpf(dommain.CPF).IdPessoaLoja;

                //CustomHelper.SetId = retorno.CPF; // retorno.IdPessoaLoja;

                CustomHelper.SetLogin(new Cliente_Models
                {

                    IdCliente = retorno.IdCliente,
                    IdPessoaLoja = retorno.IdPessoaLoja,
                    //IdConfiguracaoCliente = retorno.IdConfiguracaoCliente,
                    CodProduto = retorno.CodProduto,
                    CPF = retorno.CPF,
                    RazaoSocial = retorno.RazaoSocial,
                    IdPerfil = retorno.IdPerfil,
                    Ativacao = retorno.Ativacao,
                    Representante = retorno.Representante,
                    Pessoa = retorno.Pessoa,
                    Bairro = retorno.Bairro,
                    InscricaoMunicipal = retorno.InscricaoMunicipal,
                    Cnpj = retorno.Cnpj,
                });


            }

            if (CustomHelper.IsLogado)
                return RedirectToAction("index", "home");
            else
            {
                TempData["error"] = "Nenhum usuário encontrado.";
                return View(dommain);
            }
        }

        //public ActionResult Index(sosportalcliente_Dommain dommain)
        //{
        //    SetLogin(dommain.CPF);

        //    var retorno = this._clienteApp.Login(dommain.CPF, dommain.Senha);

        //    if (retorno != null)
        //    {
        //        //Cliente_Models.SetLogin(retorno);



        //        //Loja_Models.GetLoginLojaModel(new Loja_Models
        //        //{
        //        //    IdLoja = retorno.IdLoja,
        //        //    Cnpj = retorno.Cnpj,
        //        //    NomeFantasia = retorno.NomeFantasia,
        //        //    Telefone = retorno.Telefone,
        //        //    //Datacadastro = retorno.Datacadastro,
        //        //    Endereco = retorno.Endereco,
        //        //    Complemento = retorno.Complemento,
        //        //    Numero = retorno.Numero,
        //        //    Cep = retorno.Cep,
        //        //    Senha = retorno.Senha,
        //        //    Status = retorno.Status,
        //        //    ResponsavelCadastro = retorno.ResponsavelCadastro,
        //        //    PerfilLoja = retorno.PerfilLoja,
        //        //});
        //    }

        //    if (Cliente_Models.IsLogadoLoja())
        //        return RedirectToAction("index", "home");
        //    else
        //    {
        //        TempData["error"] = "Nenhum usuário encontrado.";
        //        return View(dommain);
        //    }
        //}

        public ActionResult Logoff()
        {
            CustomHelper.LogOff();
            return RedirectToAction("index", "Login");

        }

    }
}
