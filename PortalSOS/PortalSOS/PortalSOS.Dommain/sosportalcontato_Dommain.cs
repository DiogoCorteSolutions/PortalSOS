using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class sosportalcontato_Dommain
    {
        public int IdContato { get; set; }
        public string Telefone { get; set; }
        public string TipoTel { get; set; }
        public string Operadora { get; set; }
        public string Celular { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }


        //public sosportalcontato_Dommain()
        //{
        //    this.sosportalclientes = new List<sosportalcliente_Dommain>();
        //}

        //public int IdContato { get; set; }
        //public string Telefone { get; set; }
        //public string TipoTel { get; set; }
        //public string Operadora { get; set; }
        //public string Celular { get; set; }
        //public virtual ICollection<sosportalcliente_Dommain> sosportalclientes { get; set; }
    }
}
