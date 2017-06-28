using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace PortalSos.Infra.CrossCutting.Common.Helpers
{
    public static class SendMailHelper
    {
        public static bool SendMail(ContactMessageHelper message, bool isBodyHtml)
        {
            try
            {
                var text = HttpUtility.HtmlEncode(message.Body);

                var username = ConfigurationManager.AppSettings["Username"];
                var password = ConfigurationManager.AppSettings["Password"];
                var subject = ConfigurationManager.AppSettings["Subject"];
                var server = ConfigurationManager.AppSettings["Server"];
                var port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                
                var msg = new MailMessage();
                msg.From = new MailAddress(username, message.Subject);

                foreach (var item in message.Destination.Replace(" ", "").Split(',').ToList())
                    msg.To.Add(new MailAddress(item));

                msg.Subject = message.Subject;

                msg.IsBodyHtml = isBodyHtml;
                if (isBodyHtml)
                    msg.Body = message.Body;
                else
                    msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(
                        text, null, MediaTypeNames.Text.Plain)
                    );

                msg.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                msg.HeadersEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
                msg.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                var smtpClient = new SmtpClient(server, port);

                smtpClient.UseDefaultCredentials = false;
                var credentials = new NetworkCredential(username, password);

                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = false;
                smtpClient.Send(msg);

                return true;
            }
            catch { return false; }
        }
    }
}