using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Aplicacion_PC_Intermodular.ForgotPassword.logicMail
{
    internal class LogicEmail
    {
        public string sendMail(string to)
        {
            string msg = "error";
            string from = "wikitrail@outlook.es";
            string displayName = "WikiTrail";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, displayName);
            mail.To.Add(to);

            mail.Subject = "¿Olvidaste tu contraseña?";
            mail.Body = "La contraseña de tu cuenta es: \n" + getPasswordFromAccount(to);

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new NetworkCredential(from, "intermodulardam1234");
            client.EnableSsl = true;

            client.Send(mail);
            msg = "¡Correo enviado con éxito!";
            return msg;
        }


        private string getPasswordFromAccount(string to)
        {
            return to + " sdfsdfsdf";
        }
    }
}
