using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public abstract class Validation
    {
        public abstract bool IsCpf(string cpf);
        public abstract bool IsCnpj(string cnpj);
        public abstract string IsNumber(string value);
    }
}
