using System;
using System.Collections.Generic;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public static class GerarCupomHelper
    {
        public static IList<string> Gerar(int quantidade)
        {
            var result = new List<string>();

            for (int i = 0; i < quantidade; i++)
            {
                var cupomId = string.Format("{0}{1}", DateTime.Now.Year, Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper());
                result.Add(cupomId);
            }

            return result;
        }

        public static string Gerar()
        {
            return string.Format("{0}{1}", DateTime.Now.Year, Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper());
        }
    }
}
