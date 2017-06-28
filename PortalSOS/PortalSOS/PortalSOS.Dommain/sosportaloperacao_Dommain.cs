using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportaloperacao_Dommain
    {
        public sosportaloperacao_Dommain()
        {
            this.sosportalmovimentacaos = new List<sosportalmovimentacao_Dommain>();
        }

        public int IdOperacao { get; set; }
        public int IdTipoOperacao { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Operacao { get; set; }
        public string Tipo { get; set; }
        public string Categ { get; set; }
        public string Valor { get; set; }
        public string Ref { get; set; }
        public string Ident { get; set; }
        public bool Status { get; set; }
        public string Alteracao { get; set; }
        public string Caixa { get; set; }
        public string Turno { get; set; }
        public virtual ICollection<sosportalmovimentacao_Dommain> sosportalmovimentacaos { get; set; }
        public virtual sosportaltipooperacao_Dommain sosportaltipooperacao { get; set; }
    }
}
