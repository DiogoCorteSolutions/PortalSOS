using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSOS.Dommain
{
    public class ConfiguracaoPorLoja_Dommain
    {

        public int IdCliente { get; set; }
        public int IdPerfil { get; set; }
        public int IdPessoaLoja { get; set; }
        public int IdConfiguracao { get; set; }
        public string ControllerAction { get; set; }
        public string ViewName { get; set; }
        public int IdController { get; set; }
        public string Perfil { get; set; }

    }
}
