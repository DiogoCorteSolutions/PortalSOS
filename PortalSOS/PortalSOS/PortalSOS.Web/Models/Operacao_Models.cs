using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class Operacao_Models : BaseModels
    {
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
    }
}