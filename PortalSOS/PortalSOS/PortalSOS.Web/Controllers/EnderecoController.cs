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
    public class EnderecoController : BaseController
    {
        private readonly PortalSOS.Application.Endereco_Application _enderecoApp;
        private readonly PortalSOS.Application.UF_Application _ufApp;
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        public EnderecoController()
        {
            this._enderecoApp = new Application.Endereco_Application();
            this._ufApp = new Application.UF_Application();
            this._clienteApp = new Application.Cliente_Application();
        }
        [CustomAuthorize]
        public ActionResult EnderecoLista()
        {

            var model = new List<Endereco_Models>();

            foreach (var item in this._enderecoApp.ListarTodos())
            {
                var objeto = new Endereco_Models
                {
                    Bairro = item.Bairro,
                    CEP = item.CEP,
                    Cidade = item.Cidade,
                    CodMunicipio = item.CodMunicipio,
                    Complemento = item.Complemento,

                };

                model.Add(objeto);

            }
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult EnderecoCreate()
        {
            var model = new Endereco_Models();

            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult EnderecoCreate(Endereco_Models model)
        {
            //var final = this._clienteApp.ListarPorCpf(dommain.CPF);

            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            var clienteid = this._clienteApp.ListarPorCpf(GetLoginEndereco).IdCliente;
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();

            try
            {
                var dommain = new sosportalendereco_Dommain
                {

                    IdEndereco = model.IdEndereco,
                    //IdCliente = model.IdCliente,
                    Bairro = model.Bairro,
                    IdCliente = clienteid,
                    CEP = model.CEP,
                    Cidade = model.Cidade,
                    Complemento = model.Complemento,
                    Endereco = model.Endereco,
                    Estado = model.Estado,
                    IdUf = model.IdUf,
                    Municipio = model.Municipio,
                    CodMunicipio = model.IdUf.ToString(),
                    Numero = model.Numero,
                    UF = model.IdUf.ToString(),
                    TipoEndereco = model.TipoEndereco,
                    DescricaoTipoEndereco = model.DescricaoTipoEndereco,

                };

                if (ModelState.IsValid)
                {
                    this._enderecoApp.Salvar(dommain);
                    TempData["msgsucesso"] = "Registro Salvo com sucesso!";
                }

            }
            catch (Exception exception)
            {

                TempData["msgerror"] = exception.Message.ToString();
                return View(model);
            }
            return RedirectToAction("EnderecoCreate");
        }



    }
}
