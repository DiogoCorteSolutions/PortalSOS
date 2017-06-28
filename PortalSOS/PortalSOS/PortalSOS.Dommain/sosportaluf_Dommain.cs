using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class sosportaluf_Dommain
    {
        public sosportaluf_Dommain()
        {
            this.sosportalclientes = new List<sosportalcliente_Dommain>();
            this.sosportalenderecoes = new List<sosportalendereco_Dommain>();
        }

        public int IdUf { get; set; }
        public string UF { get; set; }
        public virtual ICollection<sosportalcliente_Dommain> sosportalclientes { get; set; }
        public virtual ICollection<sosportalendereco_Dommain> sosportalenderecoes { get; set; }


        //public sosportaluf_Dommain()
        //{
        //    this.sosportalenderecoes = new List<sosportalendereco_Dommain>();
        //}

        //public int IdUf { get; set; }
        //public string UF { get; set; }
        //public virtual ICollection<sosportalendereco_Dommain> sosportalenderecoes { get; set; }
    }
}
