using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalSOS.Web.Models
{
    public class ConfiguracaoCliente_Models : BaseModels
    {
        public int IdConfiguracaoCliente { get; set; }
        public int IdConfiguracao { get; set; }
        public int IdPerfil { get; set; }
        public bool Status { get; set; }
        public int IdCliente { get; set; }
        public int IdPessoaLoja { get; set; }
        public int TipoPessoa { get; set; }
        public int TipoPerfil { get; set; }
        public int[] ListIds { get; set; }
    }
}