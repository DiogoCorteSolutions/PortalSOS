using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class sosportalendereco_Dommain
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
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }
        public virtual sosportaluf_Dommain sosportaluf { get; set; }

        //public sosportalendereco_Dommain()
        //{
        //    this.sosportalclientes = new List<sosportalcliente_Dommain>();
        //}

        //public int IdEndereco { get; set; }
        //public string UF { get; set; }
        //public string Bairro { get; set; }
        //public string Estado { get; set; }
        //public string Cidade { get; set; }
        //public string Endereco { get; set; }
        //public string Complemento { get; set; }
        //public string Numero { get; set; }
        //public string CodMunicipio { get; set; }
        //public int IdUf { get; set; }
        //public string CEP { get; set; }
        //public string Municipio { get; set; }
        //public virtual ICollection<sosportalcliente_Dommain> sosportalclientes { get; set; }
        //public virtual sosportaluf_Dommain sosportaluf { get; set; }
    }
}
