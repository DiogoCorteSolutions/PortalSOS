using PortalSOS.Dommain;
using PortalSOS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PortalSos.Infra.CrossCutting.Common.Helpers;

namespace PortalSOS.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        //protected IEnumerable<SelectListItem> PerfilLista(IEnumerable<sosportalperfil_Dommain> lista)
        //{
        //    var retorno = new List<SelectListItem>();
        //    retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

        //    retorno.AddRange(lista.Where(x => x.Tipo == 1 && ActionDescrip)Select(item => new SelectListItem
        //    {
        //        Text = item.Perfil,
        //        Value = item.IdPerfil.ToString()

        //    }).ToList());

        //    return retorno;

        //}
        protected IEnumerable<SelectListItem> SegmentoListaFixo()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Mercado", Value = "Mercado" });
            retorno.Add(new SelectListItem { Text = "Padaria", Value = "Padaria" });
            retorno.Add(new SelectListItem { Text = "Restaurante", Value = "Restaurante" });
            retorno.Add(new SelectListItem { Text = "Borracharia", Value = "Borracharia" });
            retorno.Add(new SelectListItem { Text = "Mecanica", Value = "Mecanica" });
            retorno.Add(new SelectListItem { Text = "OUTROS", Value = "OUTROS" });

            return retorno;
        }
        protected IEnumerable<SelectListItem> PerfilLista(IEnumerable<sosportalperfil_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Where(x => x.DescricaoTipo.Contains("Perfil") && !x.Perfil.Contains("Cadastro")).Select(item => new SelectListItem
            {
                Text = item.Perfil,
                Value = item.IdPerfil.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> SegmentoLista(IEnumerable<sosportalperfil_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Where(x => x.DescricaoTipo.Contains("Segmento") && x.Tipo == 2).Select(item => new SelectListItem
            {
                Text = item.Perfil,
                Value = item.IdPerfil.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> PerfilPessoaLista(IEnumerable<sosportalperfil_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Perfil,
                Value = item.IdPerfil.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> PerfilLojaLista(IEnumerable<sosportalperfil_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Perfil,
                Value = item.IdPerfil.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> CnpjLista(IEnumerable<sosportalcliente_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Cnpj,
                Value = item.IdCliente.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> SexoLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Masculino", Value = "M" });
            retorno.Add(new SelectListItem { Text = "Feminio", Value = "F" });

            return retorno;
        }
        public IEnumerable<SelectListItem> LojaLista(IEnumerable<sosportalcliente_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Cnpj,
                Value = item.IdCliente.ToString()

            }).ToList());

            return retorno;
        }
        public IEnumerable<SelectListItem> PessoaLista(IEnumerable<sosportalcliente_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.CPF,
                Value = item.IdCliente.ToString()

            }).ToList());

            return retorno;
        }
        public IEnumerable<SelectListItem> ProdutoLista(IEnumerable<sosportalproduto_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Prod,
                Value = item.IdProduto.ToString()

            }).ToList());

            return retorno;
        }
        public IEnumerable<SelectListItem> OperacaoLista(IEnumerable<sosportaloperacao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Operacao,
                Value = item.IdOperacao.ToString()

            }).ToList());

            return retorno;
        }
        public IEnumerable<SelectListItem> TipoOperacaoLista(IEnumerable<sosportaltipooperacao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Tipo,
                Value = item.IdTipoOperacao.ToString()

            }).ToList());

            return retorno;
        }
        public IEnumerable<SelectListItem> MovimentacaoLista(IEnumerable<sosportalmovimentacao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Grupo,
                Value = item.IdMovimentacao.ToString()

            }).ToList());

            return retorno;
        }
        protected IEnumerable<SelectListItem> ControllerlLista(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            //retorno.AddRange(lista.Select(item => new SelectListItem
            //{
            //    Text = item.Controller,
            //    Value = item.Controller.ToString()

            //}).ToList());
            retorno.AddRange(lista.Where(x => x.IdController != 0).Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString(),

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> TipoPermissaooLista(IEnumerable<sosportalperfil_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.Perfil,
                Value = item.Tipo.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> TipoPermissaoLista(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ClienteLista(IEnumerable<sosportalcliente_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                Text = item.RazaoSocial,
                Value = item.IdCliente.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoListaView(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });


            retorno.AddRange(lista.Where(x => x.IdController != 0).Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString(),

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoListaController(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });


            retorno.AddRange(lista.Where(x => x.IdController == 0).Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString(),

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoListaControllerPoorFiltro(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });


            retorno.AddRange(lista.Where(x => x.IdController != 0).Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ViewName,
                Value = item.IdConfiguracao.ToString(),

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoListaIndePorIdController(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });


            retorno.AddRange(lista.Where(x => x.IdController == 75).Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString(),

            }).ToList());
            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoLista(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                //Text = item.Controller + " " + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ConfiguracaoListaControlerView(IEnumerable<sosportalconfiguracao_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                //Text = item.Controller + "/" + item.ViewName,
                Text = item.ControllerAction,
                Value = item.IdConfiguracao.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> ContatoLista(IEnumerable<sosportalcontato_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                //Text = item.Controller + "/" + item.ViewName,
                Text = item.Telefone,
                Value = item.IdContato.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> EnderecoLista(IEnumerable<sosportalendereco_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                //Text = item.Controller + "/" + item.ViewName,
                Text = item.Endereco,
                Value = item.IdEndereco.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> UFLista(IEnumerable<sosportaluf_Dommain> lista)
        {
            var retorno = new List<SelectListItem>();
            retorno.Equals(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });

            retorno.AddRange(lista.Select(item => new SelectListItem
            {
                //Text = item.Controller + "/" + item.ViewName,
                Text = item.UF,
                Value = item.IdUf.ToString()

            }).ToList());

            return retorno;

        }
        protected IEnumerable<SelectListItem> TipoPessoaLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Pessoa Fisica", Value = "1" });
            retorno.Add(new SelectListItem { Text = "Pessoa Juridica", Value = "2" });

            return retorno;
        }
        protected IEnumerable<SelectListItem> OperadoraLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "TIM", Value = "TIM" });
            retorno.Add(new SelectListItem { Text = "OI", Value = "OI" });
            retorno.Add(new SelectListItem { Text = "VIVO", Value = "VIVO" });
            retorno.Add(new SelectListItem { Text = "CLARO", Value = "CLARO" });
            retorno.Add(new SelectListItem { Text = "NEXTEL", Value = "NEXTEL" });
            retorno.Add(new SelectListItem { Text = "OUTROS", Value = "OUTROS" });

            return retorno;
        }
        protected IEnumerable<SelectListItem> TipoEnderecoLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Comercial", Value = "Comercial" });
            retorno.Add(new SelectListItem { Text = "Residencial", Value = "Residencial" });
            retorno.Add(new SelectListItem { Text = "OUTROS", Value = "OUTROS" });

            return retorno;
        }
        protected IEnumerable<SelectListItem> TipoTelefoneLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Comercial", Value = "Comercial" });
            retorno.Add(new SelectListItem { Text = "Residencial", Value = "Residencial" });
            retorno.Add(new SelectListItem { Text = "OUTROS", Value = "OUTROS" });

            return retorno;
        }
        protected IEnumerable<SelectListItem> TipoPerfilLista()
        {
            var retorno = new List<SelectListItem>();

            retorno.Add(new SelectListItem { Selected = true, Text = "Selecione", Value = "" });
            retorno.Add(new SelectListItem { Text = "Perfil", Value = "1" });
            retorno.Add(new SelectListItem { Text = "Segmento", Value = "2" });

            return retorno;
        }
        protected void SetLogin(string value)
        {
            Session["usuario"] = value;
        }
        protected string GetLogin
        {
            get
            {
                return (string)Session["usuario"];
            }
        }
        protected void cpf(string value)

        {
            Session["usuario"] = value;

        }
        protected void id(string value)

        {
            Session["usuario"] = value;

        }
        protected void SetLoginEndereco(string value)
        {
            Session["usuario"] = value;
        }
        protected string GetLoginEndereco
        {
            get
            {
                return (string)Session["usuario"];
            }
        }
        protected void setidloja(string value)

        {
            Session["usuario"] = value;

        }
        protected static string GetErrorResult(ICollection<ModelState> model)
        {
            var message = string.Join(" | ", model.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));

            return message;
        }



        #region Endereço

        [AllowAnonymous]
        public JsonResult GetZip(string cep)
        {
            try
            {
                var result = Correrio.GetAddress(cep);

                var resultJson = Json(JsonConvert.SerializeObject(new EnderecoJson(
                    result.Street,
                    result.City,
                    result.District,
                    result.Zip,
                    result.State
                )));

                var resultado = Json(resultJson.Data);

                return Json(resultado, "application/json", JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public EnderecoJson GetZipObject(string cep)
        {
            try
            {
                var result = Correrio.GetAddress(cep);

                return new EnderecoJson(
                    result.Street,
                    result.City,
                    result.District,
                    result.Zip,
                    result.State
                );
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public class EnderecoJson
        {
            public EnderecoJson(string _logradouro, string _cidade, string _bairro, string _cep, string _uf)
            {
                Logradouro = _logradouro;
                Cidade = _cidade;
                Bairro = _bairro;
                CEP = _cep;
                UF = _uf;
            }

         
            public string Logradouro { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public string CEP { get; set; }
            public string UF { get; set; }
        }

        #endregion

    }
}
