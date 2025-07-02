using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankSystem.Core.Services
{
    public interface IEmailService
    {
        bool Send(string toName, string toEmail, string subject, string bodyMail, string date, string fromName = "", string fromEmail = "", string bodyNotification = "");
    }
}
