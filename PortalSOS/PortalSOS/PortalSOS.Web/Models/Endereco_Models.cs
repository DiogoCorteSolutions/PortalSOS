using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class Endereco_Models : BaseModels
    {
        public int IdEndereco { get; set; }
        public int IdCliente { get; set; }
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
        public int TipoEndereco { get; set; }
        public string DescricaoTipoEndereco { get; set; }
    }
}