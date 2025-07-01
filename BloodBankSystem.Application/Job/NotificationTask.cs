using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;
using BloodBankSystem.Infrastructure.ExternalServices.Email;

namespace BloodBankSystem.Application.Job
{
    public class NotificationTask
    {
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly IEmailService _emailService;
        public NotificationTask(IBloodStockRepository bloodStockRepository, IEmailService emailService)
        {
            _bloodStockRepository = bloodStockRepository;
            _emailService = emailService;
        }

        public Task Execute()
        {
             var bloodStockMinimums = _bloodStockRepository.GetBloodStockBelowMinimum(4000);

            //var body = _emailService.Send("O-", 2, "Hospital Santa Clara", "contato@hospital.com");

            _emailService.Send(
                toName: "Administrador",
                toEmail: "admin@hospital.com",
                subject: "⚠️ Estoque Crítico de Sangue: O-",
                bodyMail: "",
                date: DateTime.Now.ToString("dd/MM/yyyy"),
                fromName: "Sistema Banco de Sangue",
                fromEmail: "alertas@hospital.com"
            );

            try
            {
                // Enviar Notificação
            }
            catch (Exception ex)
            {
                // Tratar o erro
            }

            Console.WriteLine("Email communication sent successfully");

            return Task.CompletedTask;

        }
    }
}
