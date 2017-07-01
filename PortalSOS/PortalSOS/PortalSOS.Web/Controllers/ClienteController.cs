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
    [CustomAuthorize]
    public class ClienteController : BaseController
    {
        //GET: /Base/
        private readonly PortalSOS.Application.Cliente_Application _clienteApp;
        private readonly PortalSOS.Application.UF_Application _ufApp;
        private readonly PortalSOS.Application.Perfil_Application _perfilApp;
        private readonly PortalSOS.Application.Endereco_Application _enderecApp;
        public ClienteController()
        {
            this._clienteApp = new Application.Cliente_Application();
            this._ufApp = new Application.UF_Application();
            this._perfilApp = new Application.Perfil_Application();
            this._enderecApp = new Application.Endereco_Application();
        }
        //GET: /Loja/
        [CustomAuthorize]
        public ActionResult ClienteLista()
        {

            var model = new List<Cliente_Models>();


            foreach (var item in this._clienteApp.ListarTodos())
            {
                var objeto = new Cliente_Models
                {
                    IdCliente = item.IdCliente,
                    CPF = item.CPF,
                    Cnae = item.Cnae,
                    Celular = item.Celular,
                    Cnpj = item.Cnpj,
                    RazaoSocial = item.RazaoSocial,
                    Endereco = item.Endereco,
                    IdPessoaLoja = item.IdPessoaLoja,
                    Pessoa = item.Pessoa,
                    Representante = item.Representante,
                    Status = item.Status,

                };

                if (objeto.IdPessoaLoja == CustomHelper.UsuarioLogado.IdCliente)
                {
                    model.Add(objeto);

                }


            }
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult ClienteCreate()
        {
            var model = new Cliente_Models();

            model.DdlOperadora = OperadoraLista();
            model.DdlTipoPessoa = TipoPessoaLista();
            model.DdlSegmentoListaFixo = SegmentoListaFixo();
            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlSegmentoLista = SegmentoLista(this._perfilApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();


            //model.MyProperty.Add(Cliente_Models);
            //model.MyProperty.Add(Cliente_Models model{

            //});


            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult ClienteCreate(Cliente_Models model)
        {
            model.DdlOperadora = OperadoraLista();
            model.DdlTipoPessoa = TipoPessoaLista();
            model.DdlSegmentoListaFixo = SegmentoListaFixo();
            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlSegmentoLista = SegmentoLista(this._perfilApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();

            model.DdlTipoTelefoneLista = TipoTelefoneLista();
            if (model.CPF != null)
            {
                SetLoginEndereco(model.CPF);
            }
            else
            {
                SetLoginEndereco(model.Cnpj);
            }

                  

            if (model.CPF == null)
            {
                model.CPF = "0";

            }

            if (this._clienteApp.Existe(model.CPF))
            {
                TempData["msgsucesso"] = "CPF Ja Cadastrado";
                return View(model);
            }


            var valid = PortalSOS.Web.custom.ValidationCPF.IsCpf(model.CPF);
            if (model.CPF == "0")
            {
                model.CPF = null;
            }


            if (valid == false && model.CPF == null && model.Cnpj != null)
            {
                valid = true;
            }

           




            //if (PortalSOS.Web.custom.ValidationCPF.IsCpf(model.CPF))
            //{
            if (valid == true)
            {
                try
                {
                    string fitrocpf = model.CPF;

                    var filtroId = CustomHelper.UsuarioLogado.IdCliente;

                    //if (model.Tipo == "2")
                    //    model.IdPessoaLoja = 0;
                    //else
                    //    model.IdPessoaLoja = CustomHelper.UsuarioLogado.IdCliente;

                    var dommain = new sosportalcliente_Dommain
                    {
                        IdCliente = model.IdCliente,
                        IdPerfil = model.IdPerfil,
                        Cnae = model.Cnae,
                        CodProduto = model.CodProduto,
                        Email = model.Email,
                        Emitente = model.Emitente,
                        Estadual = model.Estadual,
                        InscricaoMunicipal = model.InscricaoMunicipal,
                        Licenca = model.Licenca,
                        LimiteCred = model.LimiteCred,
                        Modelo = model.Modelo,
                        Obs = model.Obs,
                        Pessoa = model.Pessoa,
                        RazaoSocial = model.Pessoa,
                        Representante = model.Pessoa,
                        RG = model.RG,
                        Tipo = model.Tipo,
                        Total = model.Total,
                        Ultilizado = model.Ultilizado,
                        Ativacao = model.Ativacao,
                        Senha = model.Senha,
                        CPF = StringHelper.FormatarCpf(model.CPF),
                        Cnpj = model.Cnpj,
                        Status = true,
                        Bairro = model.Bairro,
                        CEP = model.CEP,
                        Cidade = model.Cidade,
                        CodMunicipio = model.CodMunicipio,
                        Complemento = model.Complemento,
                        Endereco = model.Endereco,
                        Estado = model.Estado,
                        IdUf = model.IdUf,
                        Municipio = model.Municipio,
                        Numero = model.Numero,
                        IdPessoaLoja = filtroId,
                        UF = model.UF,
                        Celular = model.Celular,
                        Operadora = model.Operadora,
                        Telefone = model.Telefone,
                        TipoTel = model.TipoTel,
                        TipoEndereco = model.TipoEndereco,
                        DescricaoTipoEndereco = model.DescricaoTipoEndereco,
                        Segmento = model.Segmento,
                        Rua = model.Rua,
                        Logradouro = model.Logradouro,


                    };

                    if (dommain.Tipo == "1")
                    {
                        dommain.IdPessoaLoja = filtroId;
                    }

                    if (!ModelState.IsValid)
                    {
                        TempData["msgerror"] = GetErrorResult(ModelState.Values);
                        return View(model);
                    }

                    this._clienteApp.Salvar(dommain);

                    //if (model.IdPerfil == 9)
                    //{
                    //    this._clienteApp.ListarPorCpf(model.CPF);

                    //}
                    //var final = this._clienteApp.ListarPorCpf(dommain.CPF);
                    TempData["msgsucesso"] = "Registro salvo com sucesso!";

                    var newList = this._clienteApp.ListarTodos().Where(x => x.IdPessoaLoja == model.IdCliente);


                    model.DdlOperadora = OperadoraLista();
                    model.DdlTipoPessoa = TipoPessoaLista();
                    model.DdlSegmentoListaFixo = SegmentoListaFixo();
                    model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
                    model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
                    model.DdlSegmentoLista = SegmentoLista(this._perfilApp.ListarTodos());


                    var modelfiltro = this._clienteApp.ListarPorCpf(dommain.CPF);

                    model.MyProperty.Add(model);
                    return RedirectToAction("ClienteCreate", "Cliente");
                }

                catch (Exception exception)
                {
                    TempData["msgerror"] = exception.Message.ToString();
                    return RedirectToAction("ClienteCreate", "Cliente");

                }
            }
            else
            {
                TempData["msgerror"] = "Cpf invalido";
            }

            return RedirectToAction("ClienteCreate", "Cliente");
        }


        public ActionResult ClienteEditar(int id)
        {
            var filtro = this._clienteApp.ListarPorId(id);

            var model = new Cliente_Models
            {
                IdCliente = filtro.IdCliente,
                IdPerfil = filtro.IdPerfil,
                Cnae = filtro.Cnae,
                CodProduto = filtro.CodProduto,
                Email = filtro.Email,
                Emitente = filtro.Emitente,
                Estadual = filtro.Estadual,
                InscricaoMunicipal = filtro.InscricaoMunicipal,
                Licenca = filtro.Licenca,
                LimiteCred = filtro.LimiteCred,
                Obs = filtro.Obs,
                Pessoa = filtro.Pessoa,
                RazaoSocial = filtro.Pessoa,
                Representante = filtro.Pessoa,
                RG = filtro.RG,
                Tipo = filtro.Tipo,
                Total = filtro.Total,
                Ultilizado = filtro.Ultilizado,
                Ativacao = filtro.Ativacao,
                Senha = filtro.Senha,
                CPF = filtro.CPF,
                Cnpj = filtro.Cnpj,
                Status = filtro.Status,
                Bairro = filtro.Bairro,
                CEP = filtro.CEP,
                Cidade = filtro.Cidade,
                CodMunicipio = filtro.CodMunicipio,
                Complemento = filtro.Complemento,
                Endereco = filtro.Endereco,
                Estado = filtro.Estado,
                IdUf = filtro.IdUf,
                Municipio = filtro.Municipio,
                Numero = filtro.Numero,
                IdPessoaLoja = filtro.IdPessoaLoja,
                UF = filtro.UF,
                Celular = filtro.Celular,
                Operadora = filtro.Operadora,
                Telefone = filtro.Telefone,
                TipoTel = filtro.TipoTel,
                TipoEndereco = filtro.TipoEndereco,
                DescricaoTipoEndereco = filtro.DescricaoTipoEndereco,
                Rua = filtro.Rua,
                Logradouro = filtro.Logradouro,
            };

            model.DdlOperadora = OperadoraLista();
            model.DdlTipoPessoa = TipoPessoaLista();
            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();

            return View(model);
        }
        [HttpPost, CustomAuthorize]
        public ActionResult ClienteEditar(Cliente_Models model)
        {
            model.DdlOperadora = OperadoraLista();
            model.DdlTipoPessoa = TipoPessoaLista();
            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();

            try
            {
                var filtro = this._clienteApp.ListarPorId(model.IdCliente);

                filtro.IdPerfil = model.IdPerfil;
                filtro.Cnae = model.Cnae;
                filtro.CodProduto = model.CodProduto;
                filtro.Email = model.Email;
                filtro.Emitente = model.Emitente;
                filtro.Estadual = model.Estadual;
                filtro.InscricaoMunicipal = model.InscricaoMunicipal;
                filtro.Licenca = model.Licenca;
                filtro.LimiteCred = model.LimiteCred;
                filtro.Obs = model.Obs;
                filtro.Pessoa = model.Pessoa;
                filtro.RazaoSocial = model.Pessoa;
                filtro.Representante = model.Pessoa;
                filtro.RG = model.RG;
                filtro.Tipo = model.Tipo;
                filtro.Total = model.Total;
                filtro.Ultilizado = model.Ultilizado;
                filtro.Ativacao = model.Ativacao;
                filtro.Senha = model.Senha;
                filtro.CPF = model.CPF;
                filtro.Cnpj = model.Cnpj;
                filtro.Status = model.Status;
                filtro.Bairro = model.Bairro;
                filtro.CEP = model.CEP;
                filtro.Cidade = model.Cidade;
                filtro.CodMunicipio = model.CodMunicipio;
                filtro.Complemento = model.Complemento;
                filtro.Endereco = model.Endereco;
                filtro.Estado = model.Estado;
                filtro.IdUf = model.IdUf;
                filtro.Municipio = model.Municipio;
                filtro.Numero = model.Numero;
                filtro.IdPessoaLoja = model.IdPessoaLoja;
                filtro.UF = model.UF;
                filtro.Celular = model.Celular;
                filtro.Operadora = model.Operadora;
                filtro.Telefone = model.Telefone;
                filtro.TipoTel = model.TipoTel;
                filtro.TipoEndereco = model.TipoEndereco;
                filtro.DescricaoTipoEndereco = model.DescricaoTipoEndereco;
                filtro.Rua = model.Rua;
                filtro.Logradouro = model.Logradouro;

                if (ModelState.IsValid)
                {
                    this._clienteApp.Atualizar(filtro);
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
        public ActionResult ClienteDetails(int id)
        {
            var filtro = this._clienteApp.ListarPorId(id);

            var model = new Cliente_Models
            {
                IdPerfil = filtro.IdPerfil,
                Cnae = filtro.Cnae,
                CodProduto = filtro.CodProduto,
                Email = filtro.Email,
                Emitente = filtro.Emitente,
                Estadual = filtro.Estadual,
                InscricaoMunicipal = filtro.InscricaoMunicipal,
                Licenca = filtro.Licenca,
                LimiteCred = filtro.LimiteCred,
                Obs = filtro.Obs,
                Pessoa = filtro.Pessoa,
                RazaoSocial = filtro.Pessoa,
                Representante = filtro.Pessoa,
                RG = filtro.RG,
                Tipo = filtro.Tipo,
                Total = filtro.Total,
                Ultilizado = filtro.Ultilizado,
                Ativacao = filtro.Ativacao,
                Senha = filtro.Senha,
                CPF = filtro.CPF,
                Cnpj = filtro.Cnpj,
                Status = filtro.Status,
                Bairro = filtro.Bairro,
                CEP = filtro.CEP,
                Cidade = filtro.Cidade,
                CodMunicipio = filtro.CodMunicipio,
                Complemento = filtro.Complemento,
                Endereco = filtro.Endereco,
                Estado = filtro.Estado,
                IdUf = filtro.IdUf,
                Municipio = filtro.Municipio,
                Numero = filtro.Numero,
                IdPessoaLoja = filtro.IdPessoaLoja,
                UF = filtro.UF,
                Celular = filtro.Celular,
                Operadora = filtro.Operadora,
                Telefone = filtro.Telefone,
                TipoTel = filtro.TipoTel,
                TipoEndereco = filtro.TipoEndereco,
                DescricaoTipoEndereco = filtro.DescricaoTipoEndereco,
                Rua = filtro.Rua,
                Logradouro = filtro.Logradouro,
            };

            model.DdlOperadora = OperadoraLista();
            model.DdlTipoPessoa = TipoPessoaLista();
            model.DdlUFLista = UFLista(this._ufApp.ListarTodos());
            model.DdlPerfil = PerfilLista(this._perfilApp.ListarTodos());
            model.DdlTipoEnderecoLista = TipoEnderecoLista();
            model.DdlTipoTelefoneLista = TipoTelefoneLista();

            return View(model);
        }
        [CustomAuthorize]
        public ActionResult ClienteExcluir(int id)
        {
            try
            {
                this._clienteApp.Excluir(id);
                TempData["msgsucesso"] = "Registro excluido com sucesso!";

                return RedirectToAction("clientecreate", "cliente");

            }

            catch (Exception exception)
            {
                TempData["msgerror"] = exception.Message.ToString();
                return RedirectToAction("clienteLista", "cliente");
            }
        }

    }
}
