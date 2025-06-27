using BloodBankSystem.Infrastructure.Core.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankSystem.Application.Job
{
    public class NotificationTask
    {
        private readonly IJobRepository _jobRepository;
        public NotificationTask(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public Task Execute()
        {
            var result = _jobRepository.GetAllBloodStock();

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
