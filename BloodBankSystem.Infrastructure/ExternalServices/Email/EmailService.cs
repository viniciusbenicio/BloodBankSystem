using BloodBankSystem.Core.Entities;
using BloodBankSystem.Core.Services;
using System.Net;
using System.Net.Mail;

namespace BloodBankSystem.Infrastructure.ExternalServices.Email
{
    public class EmailService : IEmailService
    {
        public bool Send(string toName, string toEmail, string subject, string bodyMail, string date, string fromName = "", string fromEmail = "", string bodyNotification = "")
        {
            var smtpClient = new SmtpClient(Configuration.SMTP.Host, Configuration.SMTP.Port)
            {
                Credentials = new NetworkCredential(Configuration.SMTP.UserName, Configuration.SMTP.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };


            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                IsBodyHtml = true
            };
            mail.To.Add(new MailAddress(toEmail, toName));

            mail.Body = bodyMail;

            try
            {
                smtpClient.Send(mail);
            }
          
            catch 
            {
                return false;
            }

            return true;
        }
       
    }
}
