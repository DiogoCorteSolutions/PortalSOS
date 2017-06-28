using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalperfil_Dommain
    {
        public sosportalperfil_Dommain()
        {
            this.sosportalclientes = new List<sosportalcliente_Dommain>();
            this.sosportalconfiguracaoclientes = new List<sosportalconfiguracaocliente_Dommain>();

        }

        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public int Tipo { get; set; }
        public string DescricaoTipo { get; set; }
        public virtual ICollection<sosportalcliente_Dommain> sosportalclientes { get; set; }
        public virtual ICollection<sosportalconfiguracaocliente_Dommain> sosportalconfiguracaoclientes { get; set; }
    }
}
