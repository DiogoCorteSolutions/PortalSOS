using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalcontasareceber_Dommain
    {
        public int IdContasAReceber { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Cliente { get; set; }
        public string Nota { get; set; }
        public string Faturado { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<System.DateTime> Vencimento { get; set; }
        public string Parcela { get; set; }
        public string Pedido { get; set; }
        public string FrmPgt { get; set; }
        public string Ndoc { get; set; }
        public bool Status { get; set; }
        public bool StatusPed { get; set; }
        public int IdCliente { get; set; }
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }
    }
}
