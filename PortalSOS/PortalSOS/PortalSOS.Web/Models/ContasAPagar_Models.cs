using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class ContasAPagar_Models : BaseModels
    {
        public int IdContasAPagar { get; set; }
        [Display(Name = "Data de Retorno")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Data { get; set; }
        //public Nullable<System.DateTime> Data { get; set; }
        public string Fornecedor { get; set; }
        public string Identificacao { get; set; }
        public string Nota { get; set; }
        public string Faturado { get; set; }
        public string Boleto { get; set; }
        [Display(Name = "Data de Retorno")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? Vencimento { get; set; }
        //public Nullable<System.DateTime> Vencimento { get; set; }
        public Nullable<decimal> valor { get; set; }
        public Nullable<decimal> Parcela { get; set; }
        public string Nf { get; set; }
        public string Nfatura { get; set; }
        public bool Status { get; set; }
        public int IdCliente { get; set; }
    }
}