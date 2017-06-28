using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class sosportalconfiguracaocliente_Dommain
    {
        public int IdConfiguracaoCliente { get; set; }
        public int IdConfiguracao { get; set; }
        public int IdPerfil { get; set; }
        public bool Status { get; set; }
        public int IdCliente { get; set; }
        public int IdPessoaLoja { get; set; }
        public int TipoPessoa { get; set; }
        public int TipoPerfil { get; set; }
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }
        public virtual sosportalconfiguracao_Dommain sosportalconfiguracao { get; set; }
        public virtual sosportalperfil_Dommain sosportalperfil { get; set; }



        //public sosportalconfiguracaocliente_Dommain()
        //{
        //    this.sosportalclientes = new List<sosportalcliente_Dommain>();
        //}

        //public int IdConfiguracaoCliente { get; set; }
        //public int IdConfiguracao { get; set; }
        //public int IdPerfil { get; set; }
        //public bool Status { get; set; }
        //public virtual ICollection<sosportalcliente_Dommain> sosportalclientes { get; set; }
        //public virtual sosportalconfiguracao_Dommain sosportalconfiguracao { get; set; }


        //public int IdConfiguracaoCliente { get; set; }
        //public int IdConfiguracao { get; set; }
        //public int IdPerfil { get; set; }
        //public bool Status { get; set; }
        //public virtual sosportalconfiguracao_Dommain sosportalconfiguracao { get; set; }
        //public virtual sosportalperfil_Dommain sosportalperfil { get; set; }
    }
}
