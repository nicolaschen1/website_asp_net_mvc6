using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AvisFormation.Logic
{
    public class EmailManager
    {
        public void SendEmail(string titre, string message, string email)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress("admin@avisformation.fr"));
            msg.Subject = "Nouveau message AvisFormations";

            msg.Body = message;
            var client = new SmtpClient
            {
                Host = "test",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 30 * 1000,
                Credentials = new NetworkCredential("admin@avisformation.fr", "test")
            };
            client.Send(msg);
        }

    }
}
