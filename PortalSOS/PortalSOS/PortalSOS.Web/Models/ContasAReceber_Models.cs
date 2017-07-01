using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class ContasAReceber_Models : BaseModels
    {
        public int IdContasAReceber { get; set; }
        [Display(Name = "Data de Retorno")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Data { get; set; }
        //public Nullable<System.DateTime> Data { get; set; }
        //public Nullable<System.DateTime> Data { get; set; }
        public string Cliente { get; set; }
        public string Nota { get; set; }
        public string Faturado { get; set; }
        public Nullable<decimal> Valor { get; set; }
        [Display(Name = "Data de Retorno")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Vencimento { get; set; }
        //public Nullable<System.DateTime> Vencimento { get; set; }
        public string Parcela { get; set; }
        public string Pedido { get; set; }
        public string FrmPgt { get; set; }
        public string Ndoc { get; set; }
        public bool Status { get; set; }
        public bool StatusPed { get; set; }
        public int IdCliente { get; set; }
    }
}