using BloodBankSystem.Core.Repositores;
using BloodBankSystem.Core.Services;

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

            foreach(var stock in bloodStockMinimums)
            {
                try
                {
                    var body = BloodStockNotificationBody(stock.BloodType, stock.QuantityML, "Hospital", "vinicius.benicio97@gmail.com");
                    _emailService.Send(toName: "Administrador", toEmail: "vinicius.benicio97@gmail.com", subject: $"⚠️ Estoque Crítico de Sangue: {stock.BloodType}", bodyMail: body, date: DateTime.Now.ToString("dd/MM/yyyy"), fromName: "Sistema Banco de Sangue", fromEmail: "vinicius.benicio97@gmail.com");

                }
                catch (Exception ex)
                {
                    // Tratar o erro
                }

            }

            Console.WriteLine("Email communication sent successfully");

            return Task.CompletedTask;

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
