using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class Configuracao_Models : BaseModels
    {

        [Display(Name = "Código")]
        public string IdLocacao { get; set; }

        public int IdConfiguracao { get; set; }
        public int IdController { get; set; }
        public int DescricaoTipoo { get; set; }
        public string ControllerAction { get; set; }
        public string ViewName { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}