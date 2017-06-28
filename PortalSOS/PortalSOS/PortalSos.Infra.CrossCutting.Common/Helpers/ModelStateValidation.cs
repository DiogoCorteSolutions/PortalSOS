using System;
using System.Linq;
using System.Web.ModelBinding;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public static class ModelStateValidation
    {
        public static string GetModelsErros(this ModelStateDictionary modelState)
        {
            return string.Join(Environment.NewLine, 
                modelState.Values.SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage + " " + v.Exception));
        }
    }
}