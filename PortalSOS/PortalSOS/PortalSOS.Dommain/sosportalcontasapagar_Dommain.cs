using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalcontasapagar_Dommain
    {
        public int IdContasAPagar { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string Fornecedor { get; set; }
        public string Identificacao { get; set; }
        public string Nota { get; set; }
        public string Faturado { get; set; }
        public string Boleto { get; set; }
        public Nullable<System.DateTime> Vencimento { get; set; }
        public Nullable<decimal> valor { get; set; }
        public Nullable<decimal> Parcela { get; set; }
        public string Nf { get; set; }
        public string Nfatura { get; set; }
        public bool Status { get; set; }
        public int IdCliente { get; set; }
        public virtual sosportalcliente_Dommain sosportalcliente { get; set; }
    }
}
