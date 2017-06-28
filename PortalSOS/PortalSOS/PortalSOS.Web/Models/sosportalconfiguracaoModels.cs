using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class sosportalconfiguracaoModels
    {
        public int IdConfiguracao { get; set; }
        public int IdController { get; set; }
        public string ControllerAction { get; set; }
        public bool Status { get; set; }
        public string ViewName { get; set; }
        public int DescricaoTipo { get; set; }
    }
}