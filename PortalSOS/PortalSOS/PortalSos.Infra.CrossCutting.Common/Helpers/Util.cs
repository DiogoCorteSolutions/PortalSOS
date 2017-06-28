using Correios.Net;
using System;
using PortalSos.Infra.CrossCutting.Common.Security;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public static class Util
    {
        public static string ToReplace(string value)
        {
            return value
                .Replace(".", "")
                .Replace(",", "")
                .Replace(@"\", "")
                .Replace("|", "")
                .Replace("/", "")
                .Replace(";", "")
                .Replace(":", "")
                .Replace("@", "")
                .Replace("'", "")
                .Replace("!", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("-", "")
                .Replace("_", "")
                .Replace("+", "")
                .Replace("¨", "")
                .Replace("%", "")
                .Replace("%", "")
                .Replace("$", "")
                .Replace("#", "")
                .Replace("?", "")
                .Replace(" ", "");
        }

        public static string AddMascaraCnpj(string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? string.Format("{0}.{1}.{2}/{3}-{4}",
                        value.Substring(0, 2), value.Substring(2, 3), value.Substring(5, 3),
                        value.Substring(8, 4), value.Substring(12, 2)) :
                        null;
        }

        public static string AddMascaraReal(decimal value)
        {
            return (value != 0) ? string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", value) : "0";
        }

        public static string AddMascaraRealSemSimbolo(decimal value)
        {
            return (value != 0) ? string.Format(System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", value) : "0";
        }

        public static string AddMascaraData(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("dd/MMM/yyyy") : null;
        }

        public static string ReduzirTamanhoTexto(string texto, int valorFinal, int valorInicial = 0)
        {
            if (!string.IsNullOrWhiteSpace(texto) && valorFinal > 0)
                if (texto.Length > valorFinal)
                    texto = string.Format("{0}...", texto.Substring(valorInicial, valorFinal));

            return texto;
        }

        public static string DecryptId(string value)
        {
            return (!string.IsNullOrWhiteSpace(value) && value != "0") ? CriptografiaSecurity.DecryptTwo(EncrypAndDecryptSecurity.Decrypt(value)) : "0";
        }

        public static string EncryptId(string value)
        {
            return (!string.IsNullOrWhiteSpace(value) && value != "0") ? CriptografiaSecurity.EncryptTwo(EncrypAndDecryptSecurity.Encrypt(value)) : "0";
        }

        public static string ToTitleCase(string value)
        {
            return (!string.IsNullOrWhiteSpace(value)) ? System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()) : value;
        }

        public static string DecryptPassword(string value)
        {
            return (!string.IsNullOrWhiteSpace(value)) ? CriptografiaSecurity.DecryptOne(value) : value;
        }

        public static string EncryptPassword(string value)
        {
            return (!string.IsNullOrWhiteSpace(value)) ? CriptografiaSecurity.EncryptOne(value) : value;
        }

        public static string GeneratePassword
        {
            get
            {
                return CriptografiaSecurity.CreatePassword();
            }
        }

        public static Address BuscarCep(string cep)
        {
            return (!string.IsNullOrWhiteSpace(cep)) ? Correrio.GetAddress(cep) : null;
        }

        public static string GetImage(string controller)
        {
            switch (controller)
            {
                case "home":
                    return "";

                case "sobre":
                    return "/content/images/page-about-banner-1.jpg";

                case "beneficios":
                    return "/content/images/page-about-banner-2.jpg";

                case "plano":
                    return "/content/images/page-about-banner-1.jpg";

                case "contato":
                    return "/content/images/page-contact-banner.jpg";

                default:
                    return null;
            }
        }

        public static string GetClass(string controller, string action)
        {
            switch (controller.ToLower())
            {
                case "home":
                    return "front no-trans";

                case "sobre":
                    return "no-trans";

                case "cadastre":
                    return "no-trans";

                case "beneficios":
                    return "no-trans";

                case "plano":
                    return "no-trans";

                case "contato":
                    return "no-trans";

                case "loja":
                    if (action == "details")
                        return "no-trans";
                    else
                        return "front no-trans";

                case "login":
                    return "full-height no-trans";
                default:
                    return null;

            }
        }

        public static string GetPage(string controller)
        {
            switch (controller.ToLower())
            {
                case "home":
                    return "Home";

                case "sobre":
                    return "Sobre";

                case "beneficios":
                    return "Benefícios";

                case "plano":
                    return "Planos";

                case "contato":
                    return "Contato";

                default:
                    return null;

            }
        }

        public static string KeySessionMenu
        {
            get { return "_key_menu_logado_"; }
        }

        #region Decrypt

        public static string EncryptOne(string value)
        {
            return value != null ? CriptografiaSecurity.EncryptOne(value) : null;
        }

        public static string DecryptOne(string value)
        {
            return value != null ? CriptografiaSecurity.DecryptOne(value) : null;
        }

        public static string EncryptTwo(string value)
        {
            return value != null ? CriptografiaSecurity.EncryptTwo(value) : null;
        }

        public static string DecryptTwo(string value)
        {
            return value != null ? CriptografiaSecurity.DecryptTwo(value) : null;
        }

        #endregion
    }
}