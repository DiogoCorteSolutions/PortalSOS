using System;
using System.Collections.Generic;

namespace PortalSOS.Dommain
{
    public partial class sosportalconfiguracaopessoa_Dommain
    {
        public int IdSosPortalConfiguracaoPessoa { get; set; }
        public int IdConfiguracao { get; set; }
        public int IdPortalPessoa { get; set; }
        public int IdPortalLoja { get; set; }
        public Nullable<bool> Status { get; set; }
        public virtual sosportalloja_Dommain sosportalloja { get; set; }
        public virtual sosportalpessoa_Dommain sosportalpessoa { get; set; }
    }
}
