using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class Contato_Models : BaseModels
    {
        public int IdContato { get; set; }
        public string Telefone { get; set; }
        public string TipoTel { get; set; }
        public string Operadora { get; set; }
        public string Celular { get; set; }
    }
}