using BloodBankSystem.Core.Entities;
using BloodBankSystem.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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

            toEmail = "vinicius.benicio97@gmail.com";
            fromEmail = toEmail;

            var mail = new MailMessage
            {
                From = new MailAddress(fromEmail, fromName),
                Subject = subject,
                IsBodyHtml = true
            };
            mail.To.Add(new MailAddress(toEmail, toName));

            string body = bodyMail;


            body = this.BloodStockNotificationBody("A", 100, "Teste", "admin@hospital.com");

            mail.Body = body;

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


        public string BloodStockNotificationBody(string bloodType, int currentQuantity, string hospitalName, string contactEmail)
        {
            return $@"
<!DOCTYPE html>
<html lang='pt-BR'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Alerta de Estoque Crítico</title>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f9f9f9;
            color: #333;
            padding: 20px;
        }}
        .container {{
            max-width: 600px;
            margin: auto;
            background-color: #ffffff;
            padding: 30px;
            border-radius: 8px;
            border: 1px solid #ddd;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.05);
        }}
        h1 {{
            color: #d9534f;
        }}
        p {{
            font-size: 16px;
        }}
        .blood-type {{
            font-size: 18px;
            font-weight: bold;
            color: #c9302c;
        }}
        .footer {{
            margin-top: 30px;
            font-size: 12px;
            color: #777;
            border-top: 1px solid #eee;
            padding-top: 15px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <h1>⚠️ Alerta de Estoque Crítico</h1>
        <p>Prezado(a),</p>
        <p>O sistema detectou que o <strong>estoque de sangue</strong> do tipo:</p>
        <p class='blood-type'>Tipo Sanguíneo: {bloodType}</p>
        <p>está abaixo do nível mínimo necessário.</p>
        <p><strong>Quantidade atual:</strong> {currentQuantity} unidades</p>
        <p>Por favor, providencie a reposição o quanto antes para garantir a continuidade dos atendimentos.</p>
        <p>Atenciosamente,<br><strong>{hospitalName}</strong><br>{contactEmail}</p>
        <div class='footer'>
            <p>Esta é uma mensagem automática gerada pelo sistema de gerenciamento de banco de sangue. Não responda este e-mail.</p>
        </div>
    </div>
</body>
</html>";
        }
    }
}
