using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace PortalSOS.Web.Models
{
    public class Cliente_Models : BaseModels
    {
        public int IdCliente { get; set; }
        public int IdPerfil { get; set; }
        public int IdPerfilLoja { get; set; }
        public string Email { get; set; }
        public string Pessoa { get; set; }
        //[Required(ErrorMessage = "* Campo Primeiro Nome obrigátorio")]//StringLength(30, ErrorMessage = "O máximo são 30 caracteres")]
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Estadual { get; set; }
        public string Cnae { get; set; }
        public Nullable<int> CodProduto { get; set; }
        public string Licenca { get; set; }
        public string Ativacao { get; set; }
        public Nullable<decimal> Total { get; set; }
        public string Obs { get; set; }
        public Nullable<decimal> LimiteCred { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Emitente { get; set; }
        public string Modelo { get; set; }
        public string CPF { get; set; }
        public string Tipo { get; set; }
        public string Representante { get; set; }
        public string Ultilizado { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public Nullable<int> IdPessoaLoja { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string CodMunicipio { get; set; }
        public int IdUf { get; set; }
        public string CEP { get; set; }
        public string Municipio { get; set; }
        public string Telefone { get; set; }
        public string TipoTel { get; set; }
        public string Operadora { get; set; }
        public string Celular { get; set; }
        public int TipoEndereco { get; set; }
        public string DescricaoTipoEndereco { get; set; }
        public string Segmento { get; set; }
        public string Rua { get; set; }
        public string Logradouro { get; set; }

        public Cliente_Models()
        {
            MyProperty = new List<Cliente_Models>();
            newList = new List<Cliente_Models>();
        }
        public IList<Cliente_Models> MyProperty { get; set; }

        public IList<Cliente_Models> newList { get; set; }

    }
}