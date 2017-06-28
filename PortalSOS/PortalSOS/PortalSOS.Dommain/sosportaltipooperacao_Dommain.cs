using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportaltipooperacao_Dommain
    {
        public sosportaltipooperacao_Dommain()
        {
            this.sosportaloperacaos = new List<sosportaloperacao_Dommain>();
        }

        public int IdTipoOperacao { get; set; }
        public string Cc { get; set; }
        public string Tipo { get; set; }
        public string Tipo2 { get; set; }
        public bool Status { get; set; }
        public string Operacao { get; set; }
        public virtual ICollection<sosportaloperacao_Dommain> sosportaloperacaos { get; set; }
    }
}
