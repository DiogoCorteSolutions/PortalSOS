using Correios.Net;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public class Correrio
    {
        public Correrio() { }

        public static Address GetAddress(string cep, int timeout = 10000)
        {
            const string url = "http://m.correios.com.br/movel/buscaCepConfirma.do";
            string dataToPost = string.Format("cepEntrada={0}&tipoCep=&cepTemp=&metodo=buscarCep", cep);
            const string method = "POST";
            const string contentType = "application/x-www-form-urlencoded";

            var request = new Request(url, dataToPost, method, contentType);
            Response response = request.Send(timeout);
            return response.ToAddress();
        }

        private class Response
        {
            /// <summary>
            /// Texto de resposta recebido do servidor.
            /// </summary>
            public String Text { get; set; }

            /// <summary>
            ///  Construtor
            /// </summary>
            /// <param name="responseText">
            /// HTML retornado pelo servidor que
            /// será usado para construir o endereço
            /// </param>
            public Response(string responseText)
            {
                this.Text = responseText;
            }

            /// <summary>
            /// Método responsável por capturar um componente do endereço
            /// na responsta do servidor. Por Macelo de Souza.
            /// </summary>
            /// 
            /// <param name="tag"></param>
            /// <returns></returns>
            private string GetValueByTag(string tag)
            {
                try
                {
                    string value = this.Text;

                    value = value.Replace("\r", "").Replace("\n", "");
                    value = value.Substring(value.IndexOf("<span class=\"resposta\">" + tag));
                    value = value.Substring(value.IndexOf("<span class=\"respostadestaque\">") + 31);

                    string result = value.Substring(0, value.IndexOf("</span>"));
                    return result.Trim();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return String.Empty;
                }
            }

            /// <summary>
            /// Método responsável por realizar a conversão
            /// da resposta recebida do servidor para um objeto
            /// do tipo Address.
            /// </summary>
            /// <returns></returns>
            public Address ToAddress()
            {
                if (IsInValidResponse())
                {
                    return new Address
                    {
                        Street = "Não encontrado",
                        City = "Não encontrado",
                        UniqueZip = false
                    };
                }

                var address = new Address
                {
                    Street = this.GetValueByTag("Logradouro"),
                    District = this.GetValueByTag("Bairro"),
                    City = Regex.Match(this.GetValueByTag("Localidade"), "^(.*?)   ").Groups[1].Value,
                    State = Regex.Match(this.GetValueByTag("Localidade"), "([A-Z]{2})$").Groups[1].Value,
                    Zip = this.GetValueByTag("CEP")
                };

                if (address.Street == String.Empty)
                {
                    address.UniqueZip = true;
                }
                else if (address.Street.Contains(" -"))
                {
                    address.Street = address.Street.Substring(0, address.Street.IndexOf(" -"));
                }

                return address;
            }

            /// <summary>
            /// Verifica se retornou algum erro
            /// </summary>
            /// <returns>
            /// True caso tenha recebido uma mensagem de erro
            /// </returns>
            private bool IsInValidResponse()
            {
                return this.Text.Contains("<div class=\"erro\">");
            }
        }

        private class Request
        {
            public string Url { get; set; }
            public string DataToSend { get; set; }
            public string Method { get; set; }
            public string ContentType { get; set; }

            /// <summary>
            /// Construtor, responsável por construir a requisição
            /// que será enviada para o site dos correios.
            /// </summary>
            /// 
            /// <param name="url">Url que será acessada</param>
            /// <param name="dataToSend">Dados que serão enviados</param>
            /// <param name="method">Método da requisição</param>
            /// <param name="contentType">Tipo do dado enviado para o servidor</param>
            public Request(string url, string dataToSend, string method, string contentType)
            {
                this.Url = url;
                this.DataToSend = dataToSend;
                this.Method = method;
                this.ContentType = contentType;
            }

            /// <summary>
            /// Envia a requisição construida através dos parâmetros
            /// passados para o construtor para o servidor e retorna
            /// a resposta recebida.
            /// </summary>
            /// <param name="timeout">Timeout em milisegundos</param>
            /// <returns>Response</returns>
            public Response Send(int timeout)
            {
                var request = (HttpWebRequest)WebRequest.Create(this.Url);
                request.Timeout = timeout;
                request.Method = this.Method;
                request.ContentType = this.ContentType;
                byte[] postBytes = Encoding.ASCII.GetBytes(this.DataToSend);

                request.GetRequestStream()
                    .Write(postBytes, 0, postBytes.Length);

                string responseText = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.GetEncoding("ISO-8859-1")).ReadToEnd();

                return new Response(responseText);
            }
        }
    }
}