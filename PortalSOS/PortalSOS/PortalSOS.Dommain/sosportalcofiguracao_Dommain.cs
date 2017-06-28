using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{

    public partial class sosportalconfiguracao_Dommain
    {
        public sosportalconfiguracao_Dommain()
        {
            this.sosportalconfiguracaoclientes = new List<sosportalconfiguracaocliente_Dommain>();
        }
        public int IdConfiguracao { get; set; }
        public int IdController { get; set; }
        public string ControllerAction { get; set; }
        public Nullable<bool> Status { get; set; }
        public string ViewName { get; set; }
        public int DescricaoTipo { get; set; }
        public virtual ICollection<sosportalconfiguracaocliente_Dommain> sosportalconfiguracaoclientes { get; set; }
        //public sosportalconfiguracao_Dommain()
        //{
        //    this.sosportalconfiguracaoclientes = new List<sosportalconfiguracaocliente_Dommain>();
        //}

        //public int IdConfiguracao { get; set; }
        //public string Controller { get; set; }

        //public int IdCliente { get; set; }
        //public virtual ICollection<sosportalconfiguracaocliente_Dommain> sosportalconfiguracaoclientes { get; set; }

    }
}
